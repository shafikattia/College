using College.Models;

namespace College.Services
{
    public class TraineeRepository : ITraineeRepository
    {
        collegecontext context;
        public TraineeRepository(collegecontext _context)
        {
            context = _context;
        }

        public List<Trainee> GetAll()
        {
           return context.Trainees.ToList();
        }
        public List<Trainee> GetAll(int id)
        {
            return context.Trainees.Where(t=>t.DeptId == id).ToList();
        }
        public Trainee GetOne(int id) 
        {
        return context.Trainees.Find(id);
        }
        public Trainee GetOne(string name)
        {
            return context.Trainees.FirstOrDefault(t=>t.Name==name);
        }
        public int Create(Trainee NewTrainee) 
        { 
           context.Trainees.Add(NewTrainee);
           var raw = context.SaveChanges();
           return raw;
        }
        public int UpDate(int id, Trainee NewTrainee) 
        {
            Trainee OldTraniee = GetOne(id);

            OldTraniee.Name = NewTrainee.Name;
            OldTraniee.Address = NewTrainee.Address;
            OldTraniee.grade = NewTrainee.grade;
            OldTraniee.DeptId = NewTrainee.DeptId;
            OldTraniee.Image = NewTrainee.Image;

            int raw = context.SaveChanges();
            return raw;
        }
        public int Delete(int id)
        {
            Trainee OldTraniee = GetOne(id);
            context.Trainees.Remove(OldTraniee);
            int raw = context.SaveChanges();
            return raw;

        }
    }
}
