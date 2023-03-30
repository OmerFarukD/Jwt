using Jwt.Core.Entities;
using Jwt.Core.Results;
using Jwt.Core.Security.JWT;
using Jwt.Entities.Dtos;

namespace Jwt.Business.Abstract;

public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IResult UserExists(string username);
    IDataResult<AccessToken> CreateToken(User user);
}