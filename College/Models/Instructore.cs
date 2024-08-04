using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Instructore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }



        [ForeignKey("Department")]
        public int DeptId { get; set; }
        
        [ForeignKey("Course")]
        public int CrsId { get; set; }

        public virtual Department Department { get; set; }
         public virtual Course Course { get; set; }

    }
}
