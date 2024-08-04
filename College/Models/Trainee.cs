using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace College.Models
{
    public class Trainee
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Trainee name is required")]
        [Display(Name = "trainee name")]
        [RegularExpression(@"^[a-z A-Z ]{3,}$", ErrorMessage = "Invalid name.")]
        [Remote(action: "NameExisrt", controller: "Trainee", ErrorMessage = "name exsit", AdditionalFields = "Id")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[^\s]+\.(jpg|jpeg|png|gif|bmp)$", ErrorMessage = "Invalid file format.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z ]{3,}$", ErrorMessage = "Invalid address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Grade is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public int grade { get; set; }


        [Required(ErrorMessage = "Department is required")]
        [ForeignKey("Department")]

        public int DeptId { get; set; }



        public virtual Department? Department { get; set; }

        public virtual ICollection<CorsResult>? CorsResults { get; set; }


    }
}
