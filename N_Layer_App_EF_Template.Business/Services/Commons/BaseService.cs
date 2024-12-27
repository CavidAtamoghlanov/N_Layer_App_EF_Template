
using N_Layer_App_EF_Template.Business.Mappings.Abstracts;
using N_Layer_App_EF_Template.DataAccess.UnitOfWorks.Abstracts;

namespace N_Layer_App_EF_Template.Business.Services.Commons;

public abstract class BaseService : ServiceResultMethod
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IAutoMapper _autoMapper;

    public BaseService(IUnitOfWork unitOfWork, IAutoMapper autoMapper)
    {
        _unitOfWork = unitOfWork;
        _autoMapper = autoMapper;
    }
}
