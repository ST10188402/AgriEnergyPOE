using System.ComponentModel.DataAnnotations;

namespace AgriEnergyPOE.ViewModels
{
    public class FarmerViewModel
    {
        public FarmerViewModel()
        {
            
        }
        public int FarmerId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Farm name is required.")]
        public string FarmName { get; set; }

        [Required(ErrorMessage = "Specialty is required.")]
        public string Specialty { get; set; }
    }
}
