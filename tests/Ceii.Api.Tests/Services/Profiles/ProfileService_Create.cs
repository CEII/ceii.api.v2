using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Profiles;
using Ceii.Api.Application.Services.Profiles;
using Ceii.Api.Application.Services.Profiles.ViewModels;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Users;
using UserProfile = Ceii.Api.Data.Entities.Users.Profile;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Profile = AutoMapper.Profile;

namespace Ceii.Api.Tests.Services.Profiles;

public class ProfileService_Create
{
    private IMapper _mapper = null!;
    private IProfileRepository _repository = null!;

    [SetUp]
    public void SetUp()
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
    public async Task Create_ShouldReturnProfile()
    {
        //Arrange
        var profile = new UserProfile()
        {
            UserEmail = new User() {Email = "00211919@uca.edu.sv"}
        };

        _repository.Insert(Arg.Any<UserProfile>()).ReturnsForAnyArgs(profile);
        var service = new ProfileService(_mapper, _repository);
        
        //Act
        var result = await service.Insert(profile);
        
        //Assert
        result.Should().BeOfType<ProfileVm>();

    }
}