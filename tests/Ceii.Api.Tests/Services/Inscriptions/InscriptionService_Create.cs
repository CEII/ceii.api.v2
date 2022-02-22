using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Inscriptions;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Inscriptions;
using Ceii.Api.Application.Services.Inscriptions.ViewModels;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Inscriptions;
using Ceii.Api.Data.Entities.Users;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Inscriptions;

public class InscriptionService_Create
{
    private IMapper _mapper = null!;
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
    public async Task Create_ShouldReturnInscription()
    {
        //Arrange 

        var ins = new Inscription()
        {
           User = new User() {Email = "00080119@uca.edu.sv"}
        };

        _repository.Insert(Arg.Any<Inscription>()).ReturnsForAnyArgs(ins);
        var service = new InscriptionService(_repository,_mapper);

        //Act
        var result = await service.Insert(ins);

        //Assert
        result.Should().BeOfType<InscriptionVm>();
    }

}
