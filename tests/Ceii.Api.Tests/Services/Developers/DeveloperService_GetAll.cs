using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Developers.ViewModels;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data.Entities.Developers;
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
    public void SetUp()
    {
        _mapper = new Mapper(
        new MapperConfiguration(cfg=>
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
       //Arrange 
       var devs = new List<Developer>()
       {
           new Developer()
           {
               User = new User() {Email = "00035420@uca.edu.sv"}
           },
           new Developer()
           {
               User = new User(){Email = "00212120@uca.edu.sv"}
           }
       };
       
       _repository.GetAll().Returns(devs);
       var service = new DevelopersServices(_mapper, _repository);
       
       //Act
       var result = await service.GetAll();
       
       //Assert
       result.Should().BeOfType<List<DeveloperVm>>().And.HaveCount(2); 
    }
}