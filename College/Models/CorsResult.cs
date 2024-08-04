   using System.ComponentModel.DataAnnotations.Schema;

    namespace College.Models
    {
        public class CorsResult
        {
            public int Id { get; set; }
            public int Degree { get; set; }



            [ForeignKey("Trainee")]
            public int TranId { get; set; }

            [ForeignKey("Course")]
            public int CrsId { get; set; }
            public virtual Trainee? Trainee { get; set; }
            public virtual Course? Course { get; set; }

        }
    }

