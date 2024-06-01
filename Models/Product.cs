using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyPOE.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }
        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }
        public Farmer? Farmer { get; set; }

    }
}
