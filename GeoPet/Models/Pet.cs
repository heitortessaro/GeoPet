namespace GeoPet.Models;

public class Pet
{
    public int Id { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    public Datetime birth { get; set; }

    [Required]
    public PetSizeEnum size { get; set; }

    [Required]
    public string caregiver { get; set; }
}