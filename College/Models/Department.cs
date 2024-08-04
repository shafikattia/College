using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Department name")]
        [Remote(action: "NameExisrt", controller: "Department", ErrorMessage = "dapartment name Already exists", AdditionalFields = "Id")]
        public string Name { get; set; }
        public string Manager { get; set; }
        public virtual ICollection<Instructore>? Instructores { get; set; }
        public virtual ICollection<Trainee>? Trainees { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
