﻿namespace GeoPet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class LocationHistory
{
    public int LocationHistoryId { get; set; }

    public string Latitute { get; set; }

    public string Longitude { get; set; }

    public DateTime TimeStamp { get; set; }

    [ForeignKey("PetId")]
    public int PetId { get; set; }

    
}

