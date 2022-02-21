using Ceii.Api.Data.Entities.Activities;

namespace Ceii.Api.Application.Services.Courses.ViewModel;

public class CourseVm
{
    public int Id { get; set; }

    public string? Title { get; set; }
    
    public bool? Enabled { get; set; }
    
    public Category? CategoryId { get; set; }
    
    public DateTime? StartstAt { get; set; }

    public DateTime? EndsAt { get; set; }
}