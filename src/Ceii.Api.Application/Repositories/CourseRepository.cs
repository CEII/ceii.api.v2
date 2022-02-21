
using Ceii.Api.Application.Common.Interfaces;
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Data.Entities.Activities;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Application.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly IApplicationDbContext _ctx;

    public CourseRepository(IApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IList<Course>> GetAll()
    {
        var courses = await _ctx.Courses.ToListAsync();
        return courses;
    }

    public Task<Course> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Insert(Course t)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Update(Course t)
    {
        throw new NotImplementedException();
    }
}