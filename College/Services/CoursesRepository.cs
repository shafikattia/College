using College.Models;

namespace College.Services
{
    public class CoursesRepository : ICoursesRepository
    {
        collegecontext context;
        public CoursesRepository(collegecontext _context)
        {
            context = _context;
        }
        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetOne(int id)
        {
            return context.Courses.Find(id);
        }
        public Course GetOne(string name)
        {
            return context.Courses.FirstOrDefault(t => t.Name == name);
        }
        public int Create(Course NewTrainee)
        {
            context.Courses.Add(NewTrainee);
            var raw = context.SaveChanges();
            return raw;
        }
        public int UpDate(int id, Course NewTrainee)
        {
            Course OldTraniee = GetOne(id);
            OldTraniee.Name = NewTrainee.Name;
            OldTraniee.Degree = NewTrainee.Degree;
            OldTraniee.MinDegree = NewTrainee.MinDegree;
            OldTraniee.DeptId = NewTrainee.DeptId;
            int raw = context.SaveChanges();
            return raw;
        }
        public int Delete(int id)
        {
            Course OldTraniee = GetOne(id);
            context.Courses.Remove(OldTraniee);
            int raw = context.SaveChanges();
            return raw;

        }

    }
}
