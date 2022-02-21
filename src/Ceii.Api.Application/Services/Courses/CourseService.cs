using AutoMapper;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Courses.ViewModel;
using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Services.Courses;

public class CourseService
{
    private readonly CourseRepository _repository;
    private readonly IMapper _mapper;


    public CourseService(IMapper mapper, CourseRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CourseVm> GetById(int id)
    {
        var course = await _repository.GetById(id);
        return _mapper.Map<Course, CourseVm>(course);
    }
}