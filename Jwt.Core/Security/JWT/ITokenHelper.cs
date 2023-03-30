using Jwt.Core.Entities;

namespace Jwt.Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user,List<Role> roles);
}

