using Jwt.Core.DataAccess;
using Jwt.Core.Entities;
using Jwt.DataAccess.Contexts;
using Jwt.DataAccess.Repositories.Abstract;


namespace Jwt.DataAccess.Repositories.Concrete;

public class RoleDal: EfEntityRepository<Role,BaseDbContext>, IRoleDal
{
    public RoleDal(BaseDbContext context) : base(context)
    {
    }
}