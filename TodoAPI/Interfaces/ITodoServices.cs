using TodoAPI.Contracts;
using TodoAPI.Models;

namespace TodoAPI.Interfaces{
    public interface ITodoServices{
        //retrieve all todo items from the database
        Task<IEnumerable<Todo>> GetAllAsync();

        //fetch a specific Todo item by its Id
        Task<Todo> GetByIdAsync(Guid id);

        //Add a new Todo item to the database
        Task CreateTodoAsync(CreateTodoRequest request);

        //Modify an existing Todo item in the database
        Task UpdateTodoAsync(Guid id, UpdateTodoRequest request);

        //Remove a Todo item from the database
        Task DeleteTodoAsync(Guid id);
    }
}