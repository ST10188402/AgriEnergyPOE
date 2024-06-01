using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyPOE.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string FarmName { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
