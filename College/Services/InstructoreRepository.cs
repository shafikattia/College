using College.Models;

namespace College.Services
{
    public class InstructoreRepository : IInstructoreRepository
    {
        collegecontext context;
        public InstructoreRepository(collegecontext _context)
        {
            context = _context;
        }


        public List<Instructore> GetAll()
        {
            return context.Instructores.ToList();
        }

        public Instructore GetOne(int id)
        {
            return context.Instructores.Find(id);
        }
        public Instructore GetOne(string name)
        {
            return context.Instructores.FirstOrDefault(t => t.Name == name);
        }
        public int Create(Instructore NewTrainee)
        {
            context.Instructores.Add(NewTrainee);
            var raw = context.SaveChanges();
            return raw;
        }
        public int UpDate(int id, Instructore NewTrainee)
        {
            Instructore OldTraniee = GetOne(id);

            OldTraniee.Name = NewTrainee.Name;
            OldTraniee.Address = NewTrainee.Address;
            OldTraniee.Salary = NewTrainee.Salary;
            OldTraniee.DeptId = NewTrainee.DeptId;
            OldTraniee.Image = NewTrainee.Image;
            OldTraniee.CrsId = NewTrainee.CrsId;

            int raw = context.SaveChanges();
            return raw;
        }
        public int Delete(int id)
        {
            Instructore OldTraniee = GetOne(id);
            context.Instructores.Remove(OldTraniee);
            int raw = context.SaveChanges();
            return raw;

        }
        public List<Instructore> GetAll(int id)
        {
            return context.Instructores.Where(t => t.DeptId == id).ToList();
        }
    }
}
