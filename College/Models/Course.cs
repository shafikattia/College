using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }

       public virtual ICollection<CorsResult> CorsResults { get; set; }
        public virtual ICollection<Instructore> Instructores { get; set; }

    }
}
