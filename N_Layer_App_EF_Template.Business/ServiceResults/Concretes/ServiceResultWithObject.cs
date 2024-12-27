using N_Layer_App_EF_Template.Business.ServiceResults.Abstracts;
using N_Layer_App_EF_Template.Domain.Enums;

namespace N_Layer_App_EF_Template.Business.ServiceResults.Concretes;

public class ServiceResultWithObject<T> : IServiceResult
{
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public string? InnerMessage { get; set; }
    public T? ResultObj { get; set; }
}
