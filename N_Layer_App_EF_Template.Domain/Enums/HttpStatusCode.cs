namespace N_Layer_App_EF_Template.Domain.Enums;

public enum HttpStatusCode
{
    Success = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    MethodNotAllowed = 405,
    RequestTimeout = 408,
    Conflict = 409,
    UnprocessableEntity = 422,
    NoContent = 204,
    InternalServerError = 500
}
