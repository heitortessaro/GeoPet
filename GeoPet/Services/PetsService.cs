using GeoPet.DTOs;
using GeoPet.Services.Interfaces;
using GeoPet.Models;
using GeoPet.Repository.Interfaces;

namespace GeoPet.Services;

public class PetsService : IPetsService
{
    private readonly IPetRepository petRepository;

    public PetsService(IPetRepository _petRepository)
    {
        petRepository = _petRepository;
    }

    public async Task<PetDTO> Add(PetDTO _pet)
    {
        petRepository.Add(_pet);
    }
}