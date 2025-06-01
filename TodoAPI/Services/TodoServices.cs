using TodoAPI.Interfaces;
using TodoAPI.Contracts;
using TodoAPI.Models;

namespace TodoAPI.Services{
    //ITodoService interface
    public class TodoServices: ITodoServices{
        //interact with the database
        private readonly TodoDbContext _context;
        //facilitate logging throughout our application
        private readonly ILogger<TodoServices> _logger;
        //
        private readonly IMapper _mapper;

        public TodoServices(TodoContext context,ILogger<TodoServices> logger, IMapper mapper){
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public Task<IEnumerable<Todo>> GetAllAsync(){
            //ToListAsync: fetch all Todo items from the database
            var todo = await _context.Todos.ToListAsync();
            if(todo == null){
                throw new Exception("No Todo items found");
            }
            return todo;
        }

        //fetch a specific Todo item by its Id
        public async Task<Todo> GetByIdAsync(Guid id){
            throw new NotImplementedException();
        }

        //Add a new Todo item to the database
        public async Task CreateTodoAsync(CreateTodoRequest request){
            try{
                var todo = _mapper.Map<Todo>(request);
                todo.CreatedAt = DateTime.UtcNow;
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
        public Task UpdateTodoAsync(Guid id, UpdateTodoRequest request){
            throw new NotImplementedException();
        }

        //Remove a Todo item from the database
        public Task DeleteTodoAsync(Guid id){
            throw new NotImplementedException();
        }

    }
}