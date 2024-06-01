using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AgriEnergyPOE.Models;

namespace AgriEnergyPOE.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            
        }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Specialty is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
        public bool IsActive { get; set; }


        [ForeignKey("Farmer")]
        public int FarmerId { get; set; } 
        public Farmer? Farmer { get; set; }
    }
}
