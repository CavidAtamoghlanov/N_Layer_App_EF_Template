using N_Layer_App_EF_Template.Domain.Enums;
using N_Layer_App_EF_Template.Domain.ResponseModels;

namespace N_Layer_App_EF_Template.Business.Responses
{
    public abstract class ResponseMethods
    {
        public static Response Success(object? content = null, string? exceptionMessage = null, string? innerExceptionMessage = null)
        {
            return new Response(HttpStatusCode.Success, content: content, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage);
        }

        public static Response Created(object? content = null)
        {
            return new Response(HttpStatusCode.Created, content: content);
        }

        public static Response NoContent()
        {
            return new Response(HttpStatusCode.NoContent);
        }

        public static Response BadRequest(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.BadRequest, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response Unauthorized(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.Unauthorized, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response Forbidden(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.Forbidden, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response NotFound(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.NotFound, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response MethodNotAllowed(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.MethodNotAllowed, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response Conflict(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.Conflict, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response UnprocessableEntity(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.UnprocessableEntity, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response Error(string exceptionMessage, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.InternalServerError, exceptionMessage: exceptionMessage, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response NotImplemented(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.NotImplemented, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response ServiceUnavailable(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.ServiceUnavailable, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response BadGateway(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.BadGateway, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }

        public static Response GatewayTimeout(string message, string? innerExceptionMessage = null, object? content = null)
        {
            return new Response(HttpStatusCode.GatewayTimeout, exceptionMessage: message, innerExceptionMessage: innerExceptionMessage, content: content);
        }
    }
}
