using Jwt.Core.DataAccess;
using Jwt.DataAccess.Contexts;
using Jwt.DataAccess.Repositories.Abstract;
using Jwt.Entities;

namespace Jwt.DataAccess.Repositories.Concrete;

public class UserRoleDal: EfEntityRepository<UserRole,BaseDbContext>, IUserRoleDal
{
    public UserRoleDal(BaseDbContext context) : base(context)
    {
    }
    
}