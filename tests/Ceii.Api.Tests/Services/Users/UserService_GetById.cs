using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Application.Services.Users.ViewModels;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Users;

public class GetById
{
    private IMapper _mapper = null!;
    private IUserRepository _repository = null!;
    
    [SetUp]
    public void SetUp()
    {
        _mapper = new Mapper(
            new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new UserMappings());
                })
        );

        _repository = Substitute.For<IUserRepository>();
    }
    
    [Test]
    public async Task GetById_ShouldReturnAnUserVm_WhenUserIsFound()
    {
        // Arrange
        var user = new User()
        {
            Email = "00019618@uca.edu.sv"
        };
        
        _repository.GetById("00019618@uca.edu.sv").Returns(user);
        var userService = new UserService(_repository, _mapper);

        // Act
        var result = await userService.GetById("00019618@uca.edu.sv");

        // Assert
        result.Should().NotBeNull()
            .And.BeOfType<UserVm>();
    }

    [Test]
    public async Task GetById_ShouldReturnNull_WhenUserIsNotFound()
    {
        // Arrange
        _repository.GetById(Arg.Any<string>()).ReturnsNull();
        var service = new UserService(_repository, _mapper);

        // Act
        var result = await service.GetById("00019618@uca.edu.sv");

        // Assert
        result.Should().BeNull();
    }
}