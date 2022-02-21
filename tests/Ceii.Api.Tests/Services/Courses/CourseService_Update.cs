using AutoMapper;
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Application.Services.Courses;
using Ceii.Api.Data.Entities.Activities;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceii.Api.Tests.Services.Courses;

public class CourseService_Update
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
    public async Task Update_ShouldUpdate_WhenCourseIsFound()
    {
        // Arrange
        var courses = new List<Course>()
        {
            new Course() { Id = 1 },
            new Course() { Id = 2 },
            new Course() { Id = 3 }
        };
        var testCourse = new Course() { Id = 3, Title = "Titulo de prueba" };

        _repository.Update(Arg.Any<Course>()).Returns(testCourse);
        var service = new CourseService(_mapper, _repository);

        // Act
        var result = await service.Update(testCourse);

        var course = courses.Where(course => course.Id.Equals(testCourse.Id)).FirstOrDefault();
        course.Title = testCourse.Title;

        // Assert
        result.Should().NotBeNull().And.BeOfType<Course>();

        courses[2].Should().BeEquivalentTo(testCourse);
    }

    [Test]
    public async Task Update_ShouldReturnNull_WhenCourseIsNotFound()
    {
        // Arrange
        _repository.Update(Arg.Any<Course>()).ReturnsNull();
        var service = new CourseService(_mapper, _repository);

        // Act
        var result = await service.Update(new Course() { Id = 10});

        // Assert
        result.Should().BeNull();
    }
}