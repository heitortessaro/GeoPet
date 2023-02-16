using GeoPet.Models;

namespace GeoPet.Repository


{
    public interface ITutorRepository
    {
        CareGivers GetTutorById(int id);
        IEnumerable<CareGivers> GetAllTutors();

        void AddTutor(CareGivers tutor);

        void UpdateTutor(CareGivers tutor);

        void DeleteTutor(int id);
    }
}
