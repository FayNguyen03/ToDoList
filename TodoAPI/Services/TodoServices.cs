using TodoAPI.Interfaces;
using TodoAPI.Contracts;
using TodoAPI.Models;
using TodoAPI.AppDataContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
 
namespace TodoAPI.Services {
    //ITodoService interface
    public class TodoServices : ITodoServices {
        //interact with the database
        private readonly TodoDbContext _context;
        //facilitate logging throughout our application
        private readonly ILogger<TodoServices> _logger;
        //object-to-object mapping using AutoMapper
        private readonly IMapper _mapper;

        public TodoServices(TodoDbContext context, ILogger<TodoServices> logger, IMapper mapper) {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        //get all Todo items from the database
        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            //ToListAsync: fetch all Todo items from the database
            var todo = await _context.Todos.ToListAsync();
            if (todo == null)
            {
                throw new Exception("No Todo items found");
            }
            return todo;
        }

        //fetch a specific Todo item by its Id
        public async Task<Todo> GetByIdAsync(Guid id) {
           var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo item with id #{id} not found.");
            }
            return todo;
        }

        //Add a new Todo item to the database
        public async Task CreateTodoAsync(CreateTodoRequest request) {
            try {
                var todo = _mapper.Map<Todo>(request);
                todo.CreatedAt = DateTime.Now;
                todo.UpdatedAt = DateTime.Now;
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the todo item.");
                throw new Exception("An error occurred while creating the todo item.");
            }
        }

        //Modify an existing Todo item in the database
        public async Task UpdateTodoAsync(Guid id, UpdateTodoRequest request)
        {
            //throw new NotImplementedException();
            try
            {
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                {
                    throw new KeyNotFoundException($"Todo item with id #{id} not found.");
                }
                if (request.Title != null)
                {
                    todo.Title = request.Title;
                }
                if (request.Content != null)
                {
                    todo.Content = request.Content;
                }
                if (request.IsComplete != null)
                {
                    todo.IsComplete = (bool) request.IsComplete;
                }
                if (request.DueDate != null)
                {
                    todo.DueDate = (DateTime)request.DueDate;
                }
                if (request.Priority != null)
                {
                    todo.Priority = (int)request.Priority;
                }
                todo.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Todo Item id #{id}");
                throw;
            }
        }

        //Remove a Todo item from the database
        public async Task DeleteTodoAsync(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No Todo item with id #{id} found");
            }
            
        }

    }
}