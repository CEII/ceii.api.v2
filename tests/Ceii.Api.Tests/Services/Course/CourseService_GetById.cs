using System.Threading.Tasks;
using AutoMapper;
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Application.Services.Courses;
using Ceii.Api.Application.Services.Courses.ViewModel;
using Ceii.Api.Application.Services.Activities;
using Ceii.Api.Data.Entities.Activities;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Ceii.Api.Tests.Services.Course;

public class CourseService_GetById
{
    private IMapper _mapper = null!;
    private ICourseRepository _repository = null!;

    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(
            new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappings()))
        );
        _repository = Substitute.For<ICourseRepository>();
    }

    [Test]
    public async Task GetById_ShouldReturnCourseVm_WhenCourseIsFound()
    {
        // //Arrange
        // var courses = new Course()
        // {
        //     Id = new Activity() { Id = 1 }
        // };
        // _repository.GetById(Arg.Any<string>()).Returns(courses);
        // var service = new CourseService(_mapper, _repository);
        //
        // //Act
        // var result = await service.GetById(1);
        //
        // //Assert
        // result.Should().NotBeNull()
        //     .And.BeOfType<CourseVm>();
    }
}

    