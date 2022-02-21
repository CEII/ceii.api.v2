using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Application.Services.Courses;
using Ceii.Api.Data.Entities.Activities;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Courses;

public class CourseService_GetAll
{
    private IMapper _mapper = null!;
    private ICourseRepository _repository = null!;
    
    
    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CourseMapping());
            })
        );
        
        _repository = Substitute.For<ICourseRepository>();
    }

    [Test]
    public async Task GetAll_ShouldReturnListOfCourses()
    {
        var courses = new List<Course>()
        {
            new Course() { Id = 1 },
            new Course() { Id = 2 },
            new Course() { Id = 3 }
        };

        _repository.GetAll().Returns(courses);
        
        var service = new CourseService(_repository, _mapper);

        var result = await service.GetAll();

        result.Should().BeOfType<List<Course>>().And.HaveCount(3);
    }
}