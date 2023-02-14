using GeoPet.Models;

namespace GeoPet.Repository.Interfaces;

public interface IPetRepository
{
    Task Add(Pet pet);
}