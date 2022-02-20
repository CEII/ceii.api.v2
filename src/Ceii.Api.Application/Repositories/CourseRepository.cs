
using Ceii.Api.Application.Contracts.Courses;
using Ceii.Api.Data.Entities.Activities;
using Ceii.Api.Data.Entities.Inscriptions;

namespace Ceii.Api.Application.Repositories;

public class CourseRepository : ICourseRepository
{
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

    public Task<Course> Update(Course t)
    {
        throw new NotImplementedException();
    }
}