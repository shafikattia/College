using College.Models;

namespace College.Services
{
    public interface ICoursesRepository
    {
        int Create(Course NewTrainee);
        int Delete(int id);
        List<Course> GetAll();
        Course GetOne(int id);
        Course GetOne(string name);
        int UpDate(int id, Course NewTrainee);
    }
}