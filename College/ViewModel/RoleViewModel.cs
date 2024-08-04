using System.ComponentModel.DataAnnotations;

namespace College.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
