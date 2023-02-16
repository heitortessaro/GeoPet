
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeoPet.Interfaces;
namespace GeoPet.Models
{

    public class CareGivers
    {
        [Key]

        public int CareGiverId { get; set; }
        public string Name { get; set; }
         
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Cep { get; set; }

    }
}