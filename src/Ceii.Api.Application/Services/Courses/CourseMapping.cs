using AutoMapper;
using Ceii.Api.Application.Services.Courses.ViewModel;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Services.Courses;

public class CourseMappings : Profile
{
    public CourseMappings()
    {
        CreateMap<Course, CourseVm>();
        CreateMap<CourseVm, Course>();
    }
}