using N_Layer_App_EF_Template.DataAccess.Contexts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Abstracts;
using N_Layer_App_EF_Template.DataAccess.Repositories.Commons;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.DataAccess.Repositories.Concretes;

public class UserRepository : Repository<User, long>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
