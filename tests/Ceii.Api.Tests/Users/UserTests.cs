using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Application.Services.Users.ViewModels;
using Ceii.Api.Data.Entities.Users;
using Moq;
using Xunit;
using FluentAssertions;

namespace Ceii.Api.Tests.Users;

public class UserTests
{
    private readonly IMapper _mapper;

    public UserTests()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile(new UserMappings())
            )
        );
    }

    [Fact]
    public async Task GetAllUsers_ShouldReturnAListOfUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Email = "00019618@uca.edu.sv" },
            new User { Email = "00167518@uca.edu.sv" },
            new User { Email = "00043818@uca.edu.sv" },
        };
        
        var repository = new Mock<IUserRepository>();
        repository.Setup(x => x.GetAll()).ReturnsAsync(users);
        
        var service = new UserService(repository.Object, _mapper);

        // Act
        var result = await service.GetAll();

        // Assert
        result.Should().NotBeEmpty().And.HaveCount(3);
        result.Should().ContainSingle(x => x.Email == "00019618@uca.edu.sv");
    }
    
    [Fact]
    public async Task GetById_ShouldReturnFoundUser()
    {
        // Arrange
        var user = new User()
        {
            Email = "00019618@uca.edu.sv"
        };

        var userVm = new UserVm()
        {
            Email = "00019618@uca.edu.sv"
        };
        
        var repository = new Mock<IUserRepository>();
        repository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(user);
        
        var service = new UserService(repository.Object, _mapper);

        // Act
        var result = await service.GetById("00019618@uca.edu.sv");

        // Assert
        result.Should().BeOfType<UserVm>();
        result.Should().BeEquivalentTo(userVm);
    }
    
    [Fact]
    public async Task GetById_ShouldReturnNullWhenNotFoundUser()
    {
        // Arrange
        var user = new User()
        {
            Email = "00019618@uca.edu.sv"
        };
        
        var repository = new Mock<IUserRepository>();
        repository.Setup(x => x.GetById(It.IsAny<string>()))!.ReturnsAsync((User) null!);
        
        var service = new UserService(repository.Object, _mapper);

        // Act
        var result = await service.GetById("not-present-email@uca.edu.sv");

        // Assert
        result.Should().BeNull();
    }
}