
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.Business.Responses;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;

namespace N_Layer_App_EF_Template.Business.Services.Commons;

public abstract class BaseService : ResponseMethods
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IAutoMapperConfiguration _autoMapper;

    public BaseService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
    {
        _unitOfWork = unitOfWork;
        _autoMapper = autoMapper;
    }
}
