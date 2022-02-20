using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Inscriptions;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Inscriptions;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Inscriptions;

public class InscriptionService_Delete
{
    private Mapper _mapper = null!;
    private InscriptionRepository _repository = null!;
    [SetUp]
    public void SetUp()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappings());
                cfg.AddProfile(new InscriptionMappings());
            })
        );
        _repository = Substitute.For<InscriptionRepository>();
    }

    [Test]
    public async Task Delete_ShouldDeleteAInscription() 
    {
        var ins = new List<Inscription>()
        {
            new Inscription() { User = new User() { Email = "00012345@uca.edu.sv"} },
            new Inscription() { User = new User() { Email = "00067890@uca.edu.sv"} },
            new Inscription() { User = new User() { Email = "00024680@uca.edu.sv"} }
        };
        _repository.Delete(Arg.Any<string>()).Returns(ins[2]);
        var service = new InscriptionService(_repository, _mapper);

        // Act
        var result = await service.Delete("00024680@uca.edu.sv");

        // Assert
        result.Should().NotBeNull().And.BeOfType<Inscription>();
    }
    [Test]
    public async Task Delete_ShouldReturnNull_WhenInscriptionIsNotFound()
    {
        // Arrange
        _repository.Delete(Arg.Any<string>()).ReturnsNull();
        var service = new InscriptionService(_repository, _mapper);

        // Act
        var result = await service.Delete("00011111@uca.edu.sv");

        // Assert
        result.Should().BeNull();
    }
}