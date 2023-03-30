using Jwt.Core.DataAccess;
using Jwt.Core.Entities;


namespace Jwt.DataAccess.Repositories.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    List<Role> GetRoles(User user);
}