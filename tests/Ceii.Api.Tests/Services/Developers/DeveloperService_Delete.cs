using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Developers;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Developers;

public class DeveloperService_Delete
{
    private IMapper _mapper = null!;
    private IDeveloperRepository _repository = null!;

    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappings());
                cfg.AddProfile(new DeveloperMappings());
            })
        );

        _repository = Substitute.For<IDeveloperRepository>();
    }

    [Test]
    public async Task Delete_ShouldDelete_WhenDeveloperIsFound()
    {
        // Arrange
        var devs = new List<Developer>()
        {
            new Developer() { User = new User() { Email = "00012345@uca.edu.sv"} },
            new Developer() { User = new User() { Email = "00067890@uca.edu.sv"} },
            new Developer() { User = new User() { Email = "00024680@uca.edu.sv"} }
        };
        _repository.Delete(Arg.Any<string>()).Returns(devs[2]);
        var service = new DevelopersServices(_mapper, _repository);

        // Act
        var result = await service.Delete("00024680@uca.edu.sv");

        var dev = devs.Where(dev => dev.User!.Email.Equals("00024680@uca.edu.sv")).FirstOrDefault();
        devs.Remove(dev);

        // Assert
        result.Should().NotBeNull().And.BeOfType<Developer>();

        var length = devs.Count();
        devs.Should().HaveCount(length).And.NotContain(dev);
    }

    [Test]
    public async Task Delete_ShouldReturnNull_WhenDeveloperIsNotFound()
    {
        // Arrange
        _repository.Delete(Arg.Any<string>()).ReturnsNull();
        var service = new DevelopersServices(_mapper, _repository);

        // Act
        var result = await service.Delete("00011111@uca.edu.sv");

        // Assert
        result.Should().BeNull();
    }
}

