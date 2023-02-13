﻿namespace GeoPet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Pets
    {
    public int PetId { get; set; }
    public string Name { get; set; }

    public string Species { get; set; }

    public 

    [ForeignKey("CareGiverId")]
    public int CareGiverId { get; set; }
}
