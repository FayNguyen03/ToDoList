using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Contracts{
    public class UpdateTodoRequest{

    public Guid id {get; set;}
    
    [StringLength(100)]
    public string? Title {get; set;}

    [StringLength(500)]
    public string? Content {get; set;}

    public bool? IsComplete {get; set;}

    public DateTime? DueDate {get; set;}

    [Range(1,5)]
    public int? Priority{get; set;}

    public UpdateTodoRequest(){
        IsComplete = false;
    }
}
}
