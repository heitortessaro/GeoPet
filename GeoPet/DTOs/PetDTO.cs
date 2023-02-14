using GeoPet.Enums;

namespace GeoPet.DTOs;

public class PetDTO
{
    public int Id { get; set; }
    public string name { get; set; }
    public Datetime birth { get; set; }
    public PetSizeEnum size { get; set; }
    public string caregiver { get; set; }
}