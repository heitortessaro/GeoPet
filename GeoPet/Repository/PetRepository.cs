using GeoPet.Models;

namespace GeoPet.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly IGeoPetContext _context;
        public PetRepository(IGeoPetContext context)
        {
            _context = context;
        }
        public void AddPet(Pets pet)
        {
           _context.Pets.Add(pet);
           _context.SaveChanges();
        }

        public void DeletePet(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.PetId == id);
            if (pet == null)
            {
                throw new Exception("Pet not found");
            }
            _context.Pets.Remove(pet);
        }

        public IEnumerable<Pets> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pets GetPetById(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.PetId == id);
            if(pet == null)
            {
                throw new Exception("Pet not found");
            }
            return pet;
        }

        public void UpdatePet(Pets pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }
    }
}
