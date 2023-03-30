using Jwt.Business.Abstract;
using Jwt.Core.Entities;
using Jwt.DataAccess.Repositories.Abstract;

namespace Jwt.Business.Concrete;

public class UserManager : IUserService
{

    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    
    public void Add(User user)
    {
        _userDal.Add(user);
    }
    
    public List<Role> GetRoles(User user) => _userDal.GetRoles(user);

    public User GetUserByEmail(string email) => _userDal.GetByFilter(x => x.Email.Equals(email));

    public User GetUserByUserName(string userName) => _userDal.GetByFilter(x => x.UserName.Equals(userName));
}