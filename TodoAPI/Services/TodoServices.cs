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
            throw new NotImplementedException();
        };

        //fetch a specific Todo item by its Id
        Task<Todo> GetByIdAsync(Guid id){
            throw new NotImplementedException();
        };

        //Add a new Todo item to the database
        Task CreateTodoAsync(CreateTodoRequest request){
            throw new NotImplementedException();
        };

        //Modify an existing Todo item in the database
        Task UpdateTodoAsync(Guid id, UpdateTodoRequest request){
            throw new NotImplementedException();
        };

        //Remove a Todo item from the database
        Task DeleteTodoAsync(Guid id){
            throw new NotImplementedException();
        };

    }
}