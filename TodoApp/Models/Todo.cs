using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public required string Description { get; set; }

        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}
