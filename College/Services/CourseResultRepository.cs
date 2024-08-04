using College.Models;

namespace College.Services
{
    public class CourseResultRepository : ICourseResultRepository
    {
        collegecontext context;
        public CourseResultRepository(collegecontext _context)
        {
            context = _context;
        }
        public List<CorsResult> GetAll()
        {
            return context.CorsResults.ToList();
        }
        public CorsResult GetOne(int TranId)
        {
            return context.CorsResults.FirstOrDefault(t => t.TranId == TranId);
        }
        public int Create(CorsResult NewTrainee)
        {
            context.CorsResults.Add(NewTrainee);
            var raw = context.SaveChanges();
            return raw;
        }
        public int UpDate(int id, CorsResult NewTrainee)
        {
            CorsResult OldTraniee = GetOne(id);
            OldTraniee.TranId = NewTrainee.TranId;
            OldTraniee.Degree = NewTrainee.Degree;
            OldTraniee.CrsId = NewTrainee.CrsId;
            int raw = context.SaveChanges();
            return raw;
        }
        public int Delete(int id)
        {
            CorsResult OldTraniee = GetOne(id);
            context.CorsResults.Remove(OldTraniee);
            int raw = context.SaveChanges();
            return raw;

        }
    }
}
