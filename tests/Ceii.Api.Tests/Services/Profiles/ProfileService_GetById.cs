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
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Profile = Ceii.Api.Data.Entities.Users.Profile;

namespace Ceii.Api.Tests.Services.Profiles;

public class ProfileService_GetById
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
    public async Task GetById_ShouldReturnProfileVm_WhenProfileIsFound()
    {
        //Arrange
        var profiles = new Profile()
        {
            UserEmail = new User() {Email = "00063820@uca.edu.sv"}
        };

        _repository.GetById(Arg.Any<string>()).Returns(profiles);
        var service = new ProfileService(_mapper, _repository);

        //Act
        var result = await service.GetById("00155619@uca.edu.sv");

        //Assert
        result.Should().NotBeNull()
            .And.BeOfType<ProfileVm>();
    }

    [Test]
    public async Task GetById_ShouldReturnNull_WhenNotFound()
    {
        //Arrange
        _repository.GetById(Arg.Any<string>()).ReturnsNull();
        var service = new ProfileService(_mapper, _repository);
        
        //Act
        var result = await service.GetById("00155619@uca.edu.sv");
        
        //Assert
        result.Should().BeNull();
    }
}

