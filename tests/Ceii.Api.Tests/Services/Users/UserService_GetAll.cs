using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Application.Services.Users.ViewModels;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Users;

public class UserService_GetAll
{
    private IMapper _mapper = null!;
    private IUserRepository _repository = null!;

    [SetUp]
    public void SetUp()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg => cfg.AddProfile(new UserMappings()))
        );

        _repository = Substitute.For<IUserRepository>();
    }

    [Test]
    public async Task GetAll_ShouldReturnListOfUserVm()
    {
        // Arrange
        var users = new List<User>
        {
            new () { Email = "00019618@uca.edu.sv" },
            new () { Email = "00167518@uca.edu.sv" },
            new () { Email = "00043818@uca.edu.sv" }
        };

        _repository.GetAll().Returns(users);
        var service = new UserService(_repository, _mapper);

        // Act
        var result = await service.GetAll();

        // Assert
        result.Should().BeOfType<List<UserVm>>().And.HaveCount(3);
    }
}