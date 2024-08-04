using College.Models;

namespace College.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {

        collegecontext context; 
        public DepartmentRepository(collegecontext _context )
        {
            context = _context;
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetOne(int id)
        {
            return context.Departments.Find(id);
        }
        public Department GetOne(string name)
        {
            return context.Departments.FirstOrDefault(t => t.Name == name);
        }
        public int Create(Department NewDepartment)
        {
            context.Departments.Add(NewDepartment);
            var raw = context.SaveChanges();
            return raw;
        }
        public int UpDate(int id, Department NewDepartment)
        {
            Department OldDepartment = GetOne(id);

            OldDepartment.Name = NewDepartment.Name;
            OldDepartment.Manager = NewDepartment.Manager;
            int raw = context.SaveChanges();
            return raw;
        }
        public int Delete(int id)
        {
            Department OldDepartment = GetOne(id);
            context.Departments.Remove(OldDepartment);
            int raw = context.SaveChanges();
            return raw;

        }
    }
}
