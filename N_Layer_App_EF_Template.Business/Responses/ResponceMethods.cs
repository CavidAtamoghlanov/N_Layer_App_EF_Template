using N_Layer_App_EF_Template.Domain.Enums;
using N_Layer_App_EF_Template.Domain.ResponseModels;

namespace N_Layer_App_EF_Template.Business.Responses
{
    public class ResponseMethods
    {
        public Response Success(object? content = null)
        {
            return new Response(HttpStatusCode.Success, content: content);
        }

        public Response BadRequest(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.BadRequest, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response NotFound(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.NotFound, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response Unauthorized(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.Unauthorized, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response Forbidden(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.Forbidden, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response Error(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.InternalServerError, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response UnprocessableEntity(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.UnprocessableEntity, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response Conflict(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.Conflict, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response NoContent()
        {
            return new Response(HttpStatusCode.NoContent);
        }

        public Response MethodNotAllowed(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.MethodNotAllowed, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response RequestTimeout(string exceptionMessage, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.RequestTimeout, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }
    }
}
