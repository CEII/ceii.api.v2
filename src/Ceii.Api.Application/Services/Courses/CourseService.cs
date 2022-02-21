using AutoMapper;
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Services.Courses;

public class CourseService
{
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IList<Course>> GetAll()
    {
        var courses = await _repository.GetAll();
        return courses;
    }
}