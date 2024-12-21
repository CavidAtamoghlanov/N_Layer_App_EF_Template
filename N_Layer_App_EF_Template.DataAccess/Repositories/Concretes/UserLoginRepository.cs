using N_Layer_App_EF_Template.DataAccess.Contexts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Commons;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.DataAccess.Repositories.Concretes;

public class UserLoginRepository : Repository<UserLogin, long>, IUserLoginRepository
{
    public UserLoginRepository(AppDbContext context) : base(context)
    {
    }
}
