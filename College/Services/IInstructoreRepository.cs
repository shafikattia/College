using College.Models;

namespace College.Services
{
    public interface IInstructoreRepository
    {
        int Create(Instructore NewTrainee);
        int Delete(int id);
        List<Instructore> GetAll();
        List<Instructore> GetAll(int id);
        Instructore GetOne(int id);
        Instructore GetOne(string name);
        int UpDate(int id, Instructore NewTrainee);
    }
}