using Jwt.Business.Abstract;
using Jwt.Core.Entities;
using Jwt.Core.Results;
using Jwt.Core.Security.Hashing;
using Jwt.Core.Security.JWT;
using Jwt.Entities.Dtos;

namespace Jwt.Business.Concrete;

public class AuthManager : IAuthService
{

    private readonly ITokenHelper _tokenHelper;
    private readonly IUserService _userService;

    public AuthManager(ITokenHelper tokenHelper, IUserService userService)
    {
        _tokenHelper = tokenHelper;
        _userService = userService;
    }

    public IDataResult<User> Register(UserForRegisterDto registerDto, string password)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        User user = new User
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        _userService.Add(user);
        return new SuccessDataResult<User>(user);
    }

    public IDataResult<User> Login(UserForLoginDto loginDto)
    {
        var userCheck = _userService.GetUserByUserName(loginDto.UserName);
        if (userCheck == null)
        {
            return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
        }
        if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
        {
            return new ErrorDataResult<User>("Parola Hatalı");
        }

        return new SuccessDataResult<User>(userCheck, "Giriş Başarılı");
    }

    public IResult UserExists(string username)
    {
        if (_userService.GetUserByUserName(username) != null)
        {
            return new ErrorResult("Kullanıcı mevcuttur.");
        }
        return new SuccessResult();
    }

    public IDataResult<AccessToken> CreateToken(User user)
    {
        var roles = _userService.GetRoles(user);
        var token = _tokenHelper.CreateToken(user, roles);
        return new SuccessDataResult<AccessToken>(token,"Access Token Başarıyla oluşturuldu" );
    }
}