using N_Layer_App_EF_Template.Domain.Enums;
using N_Layer_App_EF_Template.Domain.ResponseModels;

namespace N_Layer_App_EF_Template.Business.Responses
{
    public class ResponseMethods
    {
        public Response Success(object? content = null, string? exceptionMessage = null, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.Success, content: content, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public Response Created(object? content = null)
        {
            return new Response(HttpStatusCode.Created, content: content);
        }

        public Response NoContent()
        {
            return new Response(HttpStatusCode.NoContent);
        }

        public Response BadRequest(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.BadRequest, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response Unauthorized(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.Unauthorized, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response Forbidden(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.Forbidden, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response NotFound(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.NotFound, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response MethodNotAllowed(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.MethodNotAllowed, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response Conflict(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.Conflict, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response UnprocessableEntity(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.UnprocessableEntity, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response Error(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.InternalServerError, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response NotImplemented(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.NotImplemented, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response ServiceUnavailable(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.ServiceUnavailable, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response BadGateway(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.BadGateway, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public Response GatewayTimeout(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.GatewayTimeout, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }
    }
}
