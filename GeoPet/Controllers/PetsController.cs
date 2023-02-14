using Microsoft.AspNetCore.Mvc;
using GeoPet.DTOs;
using GeoPet.Services;

namespace GeoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class PetsController : Controller
{
    private readonly IPetsService petsService;

    public PetsController(IPetsService _petsService)
    {
        petsService = _petsService;
    }

    [HttpPost]
    public async Task<ActionResult<PetDTO>> Add(PetDTO _pet)
    {
        try
        {
            await petsService.Add(_pet);
        }
        catch (Exception err)
        {
            return BadRequest("Unable to register the pet");
        }
    }
}