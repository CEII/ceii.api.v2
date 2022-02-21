using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Data.Context;
using Ceii.Api.Data.Entities.Activities;
using Microsoft.EntityFrameworkCore;

namespace Ceii.Api.Application.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _ctx;

    public CourseRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    public Task<IList<Course>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Insert(Course t)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> Delete(object id)
    {
        var course = await _ctx.Courses.Where(course => course.Id.Equals(id)).FirstOrDefaultAsync();
        _ctx.Courses.Remove(course);
        await _ctx.SaveChangesAsync();
        return course;
    }

    public Task<Course> Update(Course t)
    {
        throw new NotImplementedException();
    }
}