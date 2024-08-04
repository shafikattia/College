using College.Models;

namespace College.Services
{
    public interface ITraineeRepository
    {
        int Create(Trainee NewTrainee);  
        int Delete(int id);
        List<Trainee> GetAll();
        List<Trainee> GetAll(int id);
         Trainee GetOne(int id);
        Trainee GetOne(string name);
        int UpDate(int id, Trainee NewTrainee);
    }
}