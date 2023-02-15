using GeoPet.Models;


namespace GeoPet.Repository


{
    public class TutorRepository : ITutorRepository
    {
        private readonly IGeoPetContext _context;
        public TutorRepository(IGeoPetContext context)
        {
            _context = context;
        }

        public CareGivers GetTutorById(int id)
        {
            var tutor = _context.CareGivers.FirstOrDefault(t => t.CareGiverId == id);
            if (tutor == null)
            {
                throw new Exception("Tutor not found");
            }
            return tutor;
        }
        public IEnumerable<CareGivers> GetAllTutors()
        {
            return _context.CareGivers.ToList();
        }

        public void AddTutor(CareGivers tutor)
        {
            _context.CareGivers.Add(tutor);
            _context.SaveChanges();
        }

        public void UpdateTutor(CareGivers tutor)
        {
            _context.CareGivers.Update(tutor);
            _context.SaveChanges();
        }
    }
}
