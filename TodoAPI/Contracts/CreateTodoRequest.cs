using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Contracts{
    public class CreateTodoRequest{

    public Guid id {get; set;}

    [Required(ErrorMessage = "The Title field is required.")]
    [StringLength(100)]
    public string Title { get; set; }

    [Required(ErrorMessage = "The Content field is required.")]
    [StringLength(500)]
    public string Content { get; set; }

    [Required(ErrorMessage = "The DueDate field is required.")]

    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "The Priority field is required.")]

    [Range(1, 5)]
    public int Priority { get; set; }
}
}
