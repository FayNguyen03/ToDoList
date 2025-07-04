using Microsoft.AspNetCore.Mvc;
using TodoAPI.Interfaces;
using TodoAPI.Contracts;

namespace TodoAPI.Controllers{
    [ApiController]
    //base route for all actions in the controller
    [Route("api/[controller]")]
    public class TodoController: ControllerBase{
        //ControllerBase: a base class provided by ASP.NET Core for creating controllers
        private readonly ITodoServices _todoServices;
        public TodoController(ITodoServices todoServices){
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
                    return Ok(new { message = "No Todo Items found" });
                }
                return Ok(new { message = "Successfully retrieved all blog posts", data = todo });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Tood it posts", error = ex.Message });

            }
        }


}
}