using GeoPet.Models;

namespace GeoPet.Repository
{
    public interface IPetRepository
    {
        Pets GetPetById(int id);
        IEnumerable<Pets> GetAllPets();

        void AddPet(Pets pet);

        void UpdatePet(Pets pet);

        void DeletePet(int id);
    }
}
