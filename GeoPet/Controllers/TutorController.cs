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
        [HttpGet]
        [Route("all")]
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
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CareGivers>> AddTutor(CareGivers tutor)
        {
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
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<CareGivers>> UpdateTutor(CareGivers tutor)
        {
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
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<CareGivers>> DeleteTutor(int id)
        {
            try
            {
                _tutorRepository.DeleteTutor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
