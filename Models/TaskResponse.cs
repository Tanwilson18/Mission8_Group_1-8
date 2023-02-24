using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Group_1_8.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Task { get; set; }
        
        public string DueDate { get; set; }

        [Required]
        [Range(1,4)]
        public byte Quadrant { get; set; }

        public bool Completed { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
