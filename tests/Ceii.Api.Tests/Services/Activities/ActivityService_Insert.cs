using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Data.Entities.Activities;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace  Ceii.Api.Tests.Services.Activities;

public class ActivityService_Insert
{
    private IMapper _mapper { get; set; }
    private IActivityRepository _repository { get; set; }
    
    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg => cfg.AddProfile(new ActivityMappings()))
        );

        _repository = Substitute.For<IActivityRepository>();
    }

    [Test]
    public async Task Insert_ShouldCreateAnActivity()
    {
        var activity = new Activity()
        {
            Id = 0,
            Title = "Cuido de computadoras",
            Description = "Como cuidar las computadoras",
            Quota = 20,
            Enabled = true,
            Mode = null,
            InvitationLink = "www.clase.com",
            CategoryId = null
        };
        
        //Arrange
        _repository.Insert(Arg.Any<Activity>()).ReturnsForAnyArgs(activity);
        var service = new ActivityService(_repository, _mapper);

        //Act
        var result = await service.Insert(activity);

        //Assert
        result.Should().NotBeNull();
    }
    
}