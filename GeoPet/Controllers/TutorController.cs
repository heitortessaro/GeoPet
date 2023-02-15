using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoPet.Interfaces;
using GeoPet.Repository;
using GeoPet.Models;
using GeoPet.Services;


namespace GeoPet.Controllers
{
    [Route("tutors")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly ViaCepAPI _viaCepAPI;
        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CareGivers>> GetTutorById(int id)
        {
            try
            {
                var tutor = _tutorRepository.GetTutorById(id);
                return Ok(tutor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<CareGivers>>> GetAllTutors()
        {
            try
            {
                var tutors = _tutorRepository.GetAllTutors();
                return Ok(tutors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<CareGivers>> AddTutor(CareGivers tutor)
        {
            var ValidCep = await _viaCepAPI.GetLocation(tutor.Address.cep);
            if (ValidCep == null)
            {
                return BadRequest("Invalid CEP");
            }
            try
            {
                _tutorRepository.AddTutor(tutor);
                return Ok(tutor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<CareGivers>> UpdateTutor(CareGivers tutor)
        {
            var ValidCep = await _viaCepAPI.GetLocation(tutor.Address.cep);
            if (ValidCep == null)
            {
                return BadRequest("Invalid CEP");
            }
            try
            {
                _tutorRepository.UpdateTutor(tutor);
                return Ok(tutor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
