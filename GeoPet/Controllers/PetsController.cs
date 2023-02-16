using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GeoPet.Interfaces;
using GeoPet.Repository;
using GeoPet.Models;
using GeoPet.Services;

namespace GeoPet.Controllers
{
    [Route("pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Pets>> AddPet(Pets pet)
        {
            if (pet == null)
            {
                return BadRequest("Invalid Pet");
            }

            try
            {
                _petRepository.AddPet(pet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pets>>> GetAllPets()
        {
            try
            {
                var pets = _petRepository.GetAllPets();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pets>> GetPetById(int id)
        {
            try
            {
                var pet = _petRepository.GetPetById(id);
                return Ok(pet);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Pets>> UpdatePet(Pets pet)
        {
            if (pet == null)
            {
                return BadRequest("Invalid Pet");
            }
            try
            {
                _petRepository.UpdatePet(pet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeletePet(int id)
        {
            try
            {
                _petRepository.DeletePet(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
