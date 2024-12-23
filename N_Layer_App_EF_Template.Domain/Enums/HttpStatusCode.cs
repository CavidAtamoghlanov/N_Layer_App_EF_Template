using System.ComponentModel;

namespace N_Layer_App_EF_Template.Domain.Enums
{
    public enum HttpStatusCode
    {
        [Description("The request has succeeded.")]
        Success = 200,

        [Description("The request has been fulfilled and resulted in a new resource being created.")]
        Created = 201,

        [Description("The request has been accepted for processing, but the processing has not been completed.")]
        Accepted = 202,

        [Description("The server successfully processed the request but is not returning any content.")]
        NoContent = 204,

        [Description("The resource has been permanently moved to a new location.")]
        MovedPermanently = 301,

        [Description("The requested resource has been temporarily moved to another location.")]
        Found = 302,

        [Description("The requested resource has not been modified since the last request.")]
        NotModified = 304,

        [Description("The server could not understand the request due to invalid syntax.")]
        BadRequest = 400,

        [Description("Authentication is required and has failed or not been provided.")]
        Unauthorized = 401,

        [Description("The client does not have access rights to the content.")]
        Forbidden = 403,

        [Description("The server can not find the requested resource.")]
        NotFound = 404,

        [Description("The request method is not supported for the requested resource.")]
        MethodNotAllowed = 405,

        [Description("The client must authenticate itself to get the requested response (proxy authentication required).")]
        ProxyAuthenticationRequired = 407,

        [Description("The server timed out waiting for the request.")]
        RequestTimeout = 408,

        [Description("The request could not be completed due to a conflict with the current state of the target resource.")]
        Conflict = 409,

        [Description("The requested resource is no longer available and will not be available again.")]
        Gone = 410,

        [Description("The request requires the client to specify the length of the content.")]
        LengthRequired = 411,

        [Description("The server understands the content type of the request but was unable to process the contained instructions.")]
        UnprocessableEntity = 422,

        [Description("The server encountered an unexpected condition that prevented it from fulfilling the request.")]
        InternalServerError = 500,

        [Description("The server does not support the functionality required to fulfill the request.")]
        NotImplemented = 501,

        [Description("The server is currently unavailable (overloaded or down).")]
        ServiceUnavailable = 503,

        [Description("The server is acting as a gateway or proxy and received an invalid response from the upstream server.")]
        BadGateway = 502,

        [Description("The server is acting as a gateway and cannot get a response in time.")]
        GatewayTimeout = 504
    }
}
