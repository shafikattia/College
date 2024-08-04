using College.Models;

namespace College.Services
{
    public interface IDepartmentRepository
    {
        int Create(Department NewDepartment);
        int Delete(int id);
        List<Department> GetAll();
        Department GetOne(int id);
        Department GetOne(string name);
        int UpDate(int id, Department NewDepartment);
    }
}