using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Domain.ResponseModels;

public class Response
{
    public HttpStatusCode StatusCode { get; set; }
    public string? ExceptionMessage { get; set; }
    public string? InnerExceptionMessage { get; set; }
    public object? Content { get; set; }

    public Response(HttpStatusCode statusCode, string? exceptionMessage = null, string? innerExceptionMessage = null, object? content = null)
    {
        StatusCode = statusCode;
        ExceptionMessage = exceptionMessage;
        InnerExceptionMessage = innerExceptionMessage;
        Content = content;
    }
}