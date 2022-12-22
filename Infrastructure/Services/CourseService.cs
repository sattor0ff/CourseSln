using Domain.Models;
namespace Infrastructure.Services;
public class CourseService
{
    private List<Course> courses;

    public CourseService()
    {
        courses = new List<Course>();
    }
    
    public List<Course> GetCourses()
    {
        return courses;
    }
    public void AddCourse(Course course)
    {
        courses.Add(course);
    }
    public void UpdateCourse(Course course)
    {
        var existing = courses.Find(x=>x.Id == course.Id);
        if(existing == null) return;

        existing.Title = course.Title;
        existing.Description = course.Description;
        existing.Free = course.Free;
        existing.HasDiscount = course.HasDiscount;
    }
    public void Delete(int id)
    {
        var existing = courses.Find(x=>x.Id == id);
        if(existing == null) return;
        courses.Remove(existing);
    }
}