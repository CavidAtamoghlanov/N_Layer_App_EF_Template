using N_Layer_App_EF_Template.Business.ServiceResults.Concretes;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.Services.Commons
{
    public abstract class ServiceResultMethod
    {
        #region Success Methods
        public static ServiceResult Success(string? message = null, string? innerMessage = null)
        {
            return new ServiceResult { StatusCode = HttpStatusCode.Success, Message = message, InnerMessage = innerMessage };
        }

        public static ServiceResultWithObject<T> Success<T>(T resultObj, string? message = null, string? innerMessage = null)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.Success, ResultObj = resultObj, Message = message, InnerMessage = innerMessage };
        }
        #endregion

        #region Created Methods
        public static ServiceResult Created()
        {
            return new ServiceResult { StatusCode = HttpStatusCode.Created };
        }

        public static ServiceResultWithObject<T> Created<T>(T resultObj)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.Created, ResultObj = resultObj };
        }
        #endregion

        #region NoContent Methods
        public static ServiceResult NoContent()
        {
            return new ServiceResult { StatusCode = HttpStatusCode.NoContent };
        }
        #endregion

        #region BadRequest Methods
        public static ServiceResult BadRequest(string message, string? innerMessage = null)
        {
            return new ServiceResult { StatusCode = HttpStatusCode.BadRequest, Message = message, InnerMessage = innerMessage };
        }

        public static ServiceResultWithObject<T> BadRequest<T>(string message, T resultObj, string? innerMessage = null)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.BadRequest, Message = message, InnerMessage = innerMessage, ResultObj = resultObj };
        }
        #endregion

        #region Unauthorized Methods
        public static ServiceResult Unauthorized(string message, string? innerMessage = null)
        {
            return new ServiceResult { StatusCode = HttpStatusCode.Unauthorized, Message = message, InnerMessage = innerMessage };
        }

        public static ServiceResultWithObject<T> Unauthorized<T>(string message, T resultObj, string? innerMessage = null)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.Unauthorized, Message = message, InnerMessage = innerMessage, ResultObj = resultObj };
        }
        #endregion

        #region Forbidden Methods
        public static ServiceResult Forbidden(string message, string? innerMessage = null)
        {
            return new ServiceResult { StatusCode = HttpStatusCode.Forbidden, Message = message, InnerMessage = innerMessage };
        }

        public static ServiceResultWithObject<T> Forbidden<T>(string message, T resultObj, string? innerMessage = null)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.Forbidden, Message = message, InnerMessage = innerMessage, ResultObj = resultObj };
        }
        #endregion

        #region NotFound Methods
        public static ServiceResult NotFound(string message, string? innerMessage = null)
        {
            return new ServiceResult { StatusCode = HttpStatusCode.NotFound, Message = message, InnerMessage = innerMessage };
        }

        public static ServiceResultWithObject<T> NotFound<T>(string message, T resultObj, string? innerMessage = null)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.NotFound, Message = message, InnerMessage = innerMessage, ResultObj = resultObj };
        }
        #endregion

        #region Error Methods
        public static ServiceResult Error(string message, string? innerMessage = null)
        {
            return new ServiceResult { StatusCode = HttpStatusCode.InternalServerError, Message = message, InnerMessage = innerMessage };
        }

        public static ServiceResultWithObject<T> Error<T>(string message, T resultObj, string? innerMessage = null)
        {
            return new ServiceResultWithObject<T> { StatusCode = HttpStatusCode.InternalServerError, Message = message, InnerMessage = innerMessage, ResultObj = resultObj };
        }
        #endregion
    }
}
