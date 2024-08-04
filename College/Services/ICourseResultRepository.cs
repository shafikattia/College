using College.Models;

namespace College.Services
{
    public interface ICourseResultRepository
    {
        int Create(CorsResult NewTrainee);
        int Delete(int id);
        List<CorsResult> GetAll();
        CorsResult GetOne(int TranId);
        int UpDate(int id, CorsResult NewTrainee);
    }
}