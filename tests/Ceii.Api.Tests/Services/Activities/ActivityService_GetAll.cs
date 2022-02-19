using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Application.Services.Activities.ViewModels;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Activity = Ceii.Api.Data.Entities.Activities.Activity;

namespace Ceii.Api.Tests.Services.Activities;

public class ActivityService_GetAll
{
    private IMapper _mapper = null!;
    private IActivityRepository _repository = null!;

    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg => cfg.AddProfile(new ActivityMappings()))
        );

        _repository = Substitute.For<IActivityRepository>();
    }

    [Test]
    public async Task GetAll_ShouldReturnListOfActivities()
    {
        var activities = new List<Activity>()
        {
            new Activity()
            {
                Title = "Just Testing"
            },
            new Activity()
            {
                Title = "Just Testing 2"
            }
        };
        
        _repository.GetAll().Returns(activities);
        var service = new ActivityService(_mapper, _repository);

        var result = await service.GetAll();

        result.Should().BeOfType<List<ActivityVm>>().And.HaveCount(2);
    }
}