using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Inscriptions;
using Ceii.Api.Application.Services.Inscriptions;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Ceii.Api.Data.Entities.Inscriptions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Inscriptions;

public class InscriptionService_GetAll
{
    private IMapper _mapper = null!;
    
    private IInscriptionRepository _repository = null!;

    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg => cfg.AddProfile(new InscriptionMappings()))
        );
        
        _repository = Substitute.For<IInscriptionRepository>();
    }

    [Test]
    public async Task GetAll_ShouldReturnListOfInscriptions()
    {
        //Arrange
        var inscriptions = new List<Inscription>()
        {
            new() {Id = 2332},
            new() {Id = 3532},
            new() {Id = 6532}
        };

        _repository.GetAll().Returns(inscriptions);
        var service = new InscriptionService(_repository, _mapper);
        
        //Act
        var result = await service.GetAll();
        
        //Assert
        result.Should().BeOfType<List<InscriptionVm>>().And.HaveCount(3);
    }
}

