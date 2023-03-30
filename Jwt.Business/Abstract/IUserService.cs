using Jwt.Core.Entities;

namespace Jwt.Business.Abstract;

public interface IUserService
{
    void Add(User user);
    List<Role> GetRoles(User user);
    User GetUserByEmail(string email);
    User GetUserByUserName(string userName);
}