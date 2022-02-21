using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Data.Entities.Activities;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Activities;

public class ActivityService_DeleteOneActivity
{
    private IMapper _mapper = null!;
    private IActivityRepository _repository = null!;

    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new ActivityMappings())));

        _repository = Substitute.For<IActivityRepository>();
    }

    [Test]
    public async Task ShouldDeleteOneActivityIfExist()
    {
        var activities = new List<Activity>()
        {
            new Activity() { Id = 1 },
            new Activity(){ Id = 2, Title = "Programando con Fer"},
            new Activity() { Id = 3 }
        };

        _repository.Delete(Arg.Any<int>()).Returns(activities[2]);
        var service = new ActivityService(_repository, _mapper);

        var result = await service.Delete(2);

        var activity = activities.FirstOrDefault(activity => activity.Id.Equals(2));
        activities.Remove(activity);

        result.Should().NotBeNull();

        var activityCount = activities.Count();
        activities.Should().HaveCount(activityCount).And.NotContain(activity);
    }

    [Test]
    public async Task ShouldReturnNullWhenActivityIsNotFound()
    {
        _repository.Delete(Arg.Any<int>()).ReturnsNull();
        var service = new ActivityService(_repository, _mapper);
        
        var result = await service.Delete(4);

        result.Should().BeNull();
    }
}