using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Developer;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Developers;

public class DeveloperService_GetById
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
    public async Task GetById_ShouldReturnDeveloperVm_WhenDeveloperIsFound()
    {
        // Arrange
        var dev = new Developer()
        {
            User = new User() {Email = "00019618@uca.edu.sv"}
        };
        
        _repository.GetById(Arg.Any<string>()).Returns(dev);
        var service = new DeveloperService(_mapper, _repository);

        // Act
        var result = await service.GetById("00019618@uca.edu.sv");
        
        // Assert
        result.Should().NotBeNull()
            .And.BeOfType<DeveloperVm>();
    }

    [Test]
    public async Task GetById_ShouldReturnNull_WhenNotFound()
    {
        // Arrange
        _repository.GetById(Arg.Any<string>()).ReturnsNull();
        var service = new DeveloperService(_mapper, _repository);

        // Act
        var result = await service.GetById("00019618@uca.edu.sv");

        // Assert
        result.Should().BeNull();
    }
}