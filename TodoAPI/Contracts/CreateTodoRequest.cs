using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Contracts{
    public class CreateTodoRequest{

    public Guid id {get; set;}
    
    [Required]
    [StringLength(100)]
    public string Title {get; set;}

    [StringLength(500)]
    public string Content{get; set;}

    [Required]
    public DateTime DueDate {get; set;}

    [Range(1,5)]
    public int Priority{get; set;}
}
}
