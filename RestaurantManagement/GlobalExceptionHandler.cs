using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace RestaurantManagement
{
    /// <summary>
    /// Handles unhandled Web API exceptions.
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Returns a generic internal server error response.
        /// </summary>
        /// <param name="context">The exception handling context.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            var response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new { Message = "An unexpected error occurred on the server. Please try again later." }
            );
            context.Result = new ResponseMessageResult(response);
        }
    }
}
