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

    public Task<Course> Delete(object id)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> Update(Course t)
    {
        var course = await _ctx.Courses.Where(course => course.Id.Equals(t.Id)).FirstOrDefaultAsync();

        if (course != null)
        {
            course.StartstAt = t.StartstAt;
            course.EndsAt = t.EndsAt;
            course.Days = t.Days;
            course.Duration = t.Duration;
            course.Title = t.Title;
            course.Description = t.Description;
            course.Title = t.Title;
            course.Quota = t.Quota;
            course.Enabled = t.Enabled;
            course.Mode = t.Mode;
            course.InvitationLink = t.InvitationLink;
            course.CategoryId = t.CategoryId;

            await _ctx.SaveChangesAsync();

            return course;
        }
        return null;
    }
}