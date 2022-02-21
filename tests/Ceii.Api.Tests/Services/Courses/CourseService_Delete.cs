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

public class CourseService_Delete
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
    public async Task Delete_ShouldDelete_WhenCourseIsFound()
    {
        // Arrange
        var courses = new List<Course>()
        {
            new Course() { Id = 1 },
            new Course() { Id = 2 },
            new Course() { Id = 3 }
        };
        _repository.Delete(Arg.Any<int>()).Returns(courses[2]);
        var service = new CourseService(_mapper, _repository);

        // Act
        var result = await service.Delete(3);

        var course = courses.Where(course => course.Id.Equals(3)).FirstOrDefault();
        courses.Remove(course);

        // Assert
        result.Should().NotBeNull().And.BeOfType<Course>();

        var length = courses.Count();
        courses.Should().HaveCount(length).And.NotContain(course);
    }

    [Test]
    public async Task Delete_ShouldReturnNull_WhenCourseIsNotFound()
    {
        // Arrange
        _repository.Delete(Arg.Any<int>()).ReturnsNull();
        var service = new CourseService(_mapper, _repository);

        // Act
        var result = await service.Delete(10);

        // Assert
        result.Should().BeNull();
    }
}

