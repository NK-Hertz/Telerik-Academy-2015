//namespace StudentSystem.Models
//{
//    using System;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;

//    public class Material
//    {
//        public Material()
//        {
//            this.Id = Guid.NewGuid();
//        }

//        public Guid Id { get; set; }
        
//        // think this through how it is handled in TA 
//        // else varbinary(max)
//        [MaxLength(255)]
//        public string FilePath { get; set; }

//        [Required]
//        [MinLength(3), MaxLength(100)]
//        public string OriginalFileName { get; set; }

//        public int? Homework { get; set; }
//        public virtual Homework Homework { get; set; }

//        public int? CourseId { get; set; }
//        public virtual Course Course { get; set; }
//    }
//}
