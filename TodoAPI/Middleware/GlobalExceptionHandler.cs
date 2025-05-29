/*Any exceptions that occur during the execution of our application caught and handled appropriately, providing meaningful error messages*/

using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using TodoAPI.Models;

namespace TodoAPI.Middleware{
    public class GlobalExceptionHandler: IExceptionHandler{
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) {
            _logger = _logger;
        }
        //this method invoked when an exception occurs: logging the error message, creating an ErrorResponse object, setting the status code and title, and returning a consistent error response to the clients
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken){
            _logger.LogError($"ERROR: {exception.Message}");
            var errorResponse = new ErrorResponse{Message = exception.Message};
            switch(exception){
                case BadHttpRequestException:   
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Title = exception.GetType().Name;
                    break;
                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Title = "Internal Server Error";
                    break;
            }
            httpContext.Response.StatusCode = errorResponse.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
            return true;
        }
        
    }
}