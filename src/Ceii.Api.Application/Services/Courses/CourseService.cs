using AutoMapper;
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Services.Courses;

public class CourseService
{
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;

    public CourseService(IMapper mapper, ICourseRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Course> Delete(int id)
    {
        var course = await _repository.Delete(id);
        return course;
    }
}