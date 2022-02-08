using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Profiles;
using Ceii.Api.Application.Services.Profiles;
using Ceii.Api.Application.Services.Profiles.ViewModels;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Profile = Ceii.Api.Data.Entities.Users.Profile;

namespace Ceii.Api.Tests.Services.Profiles;

public class ProfileService_GetAll
{
    private IMapper _mapper = null!;
    private IProfileRepository _repository = null!;


    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappings());
                cfg.AddProfile(new ProfileMappings());
            })
        );
        

        _repository = Substitute.For<IProfileRepository>();
    }

    [Test]
    public async Task GetAll_ShouldReturnListOfProfiles()
    {
        // Arrange 
        var profiles = new List<Profile>()
        {
            new Profile()
            {
                UserEmail = new User() {Email = "00063820@uca.edu.sv"}
            },
            new Profile()
            {
                UserEmail = new User() {Email = "00063821@uca.edu.sv"}
            }
        };
        _repository.GetAll().Returns(profiles);

        var service = new ProfileService(_mapper, _repository);

        // Act
        var result = await service.GetAll();

        // Assert
        result.Should().BeOfType<List<ProfileVm>>().And.HaveCount(2);
    }
}