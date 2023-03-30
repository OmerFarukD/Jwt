using Jwt.Core.DataAccess;
using Jwt.Core.Entities;
using Jwt.DataAccess.Contexts;
using Jwt.DataAccess.Repositories.Abstract;


namespace Jwt.DataAccess.Repositories.Concrete;

public class UserDal : EfEntityRepository<User,BaseDbContext>, IUserDal
{
    public UserDal(BaseDbContext context) : base(context)
    {
    }

    public List<Role> GetRoles(User user)
    {
        var result = from role in Context.Roles
            join userRole in Context.UserRoles on role.RoleId equals userRole.RoleId
            where userRole.UserId == user.UserId
            select new Role
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };

        return result.ToList();
    }
}