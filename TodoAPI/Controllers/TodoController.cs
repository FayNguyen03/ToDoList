using Microsoft.AspNetCore.Mvc;
using TodoAPI.Interfaces;
using TodoAPI.Contracts;

namespace TodoAPI.Controllers{
    [ApiController]
    //base route for all actions in the controller
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        //ControllerBase: a base class provided by ASP.NET Core for creating controllers
        private readonly ITodoServices _todoServices;
        public TodoController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync(CreateTodoRequest request)
        {
            //check if the request model is vaid
            if (!ModelState.IsValid)
            {
                //if not return the model state errors
                return BadRequest(ModelState);
            }

            try
            {
                await _todoServices.CreateTodoAsync(request);
                return Ok(new { message = "Blog post successfully created" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the  crating Todo Item", error = ex.Message });

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                //retrieve the list of todo items
                var todo = await _todoServices.GetAllAsync();
                if (todo == null || !todo.Any())
                {
                    return NotFound(new { message = "No Todo Items found" });
                }
                return Ok(new { message = "Successfully retrieved all blog posts", data = todo });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Tood it posts", error = ex.Message });

            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var todo = await _todoServices.GetByIdAsync(id);
                if (todo == null)
                {
                    return NotFound(new { message = $"Todo Item with id #{id} found." });
                }
                return Ok(new { message = $"Successfully retrieved the Todo item ${id}", data = todo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while retrieving the Todo item with Id {id}.", error = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTodoAync(Guid id, UpdateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var todo = await _todoServices.GetByIdAsync(id);
                if (todo == null)
                {
                    return NotFound(new { message = $"Todo Item with id #{id} not found." });
                }
                await _todoServices.UpdateTodoAsync(id, request);
                return Ok(new { message = $"Successfully updated the Todo item ${id}", data = todo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating the Todo item with Id {id}.", error = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTodoAsync(Guid id)
        {
            try
            {
                await _todoServices.DeleteTodoAsync(id);
                return Ok(new { message = $"Todo Item with id #{id} deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Cannot delete Todo Item with id #{id}", ex.Message });
            }

        }
    }
}