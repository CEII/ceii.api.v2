using System.Collections.Generic;
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
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Developers;

public class DeveloperService_GetAll
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
    public async Task GetAll_ShouldReturnListOfDevelopers()
    {
        // Arrange
        // preparar todos los elementos para el test
        var devs = new List<Developer>()
        {
            new Developer()
            {
                User = new User() { Email = "00019618@uca.edu.sv" }
            },
            new Developer()
            {
                User = new User() { Email = "00019618@uca.edu.sv" }
            }
        };
        
        _repository.GetAll().Returns(devs);
        var service = new DeveloperService(_mapper, _repository);

        // Act
        // realizar el metodo o la accion
        var result = await service.GetAll();

        // Assert
        // verificar que se cumpla lo esperado
        // FluentAssertions
        result.Should().BeOfType<List<DeveloperVm>>().And.HaveCount(2);
    }
}