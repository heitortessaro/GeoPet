using GeoPet.DTOs;

namespace GeoPet.Services.Interfaces;

public interface IPetsService
{
    Task Add(PetDTO pet);
}