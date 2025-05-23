using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models{
    public class Todo{
        //Id is the main way to identify each Todo item in the database
        [Key]
        public Guid Id {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public bool IsComplete {get; set;}
        public DateTime DueDate {get; set;}
        public int Priority {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public Todo(){
            IsComplete = false;
        }
    }
}