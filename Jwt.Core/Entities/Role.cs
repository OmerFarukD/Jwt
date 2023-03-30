

namespace Jwt.Core.Entities;

public class Role : IEntity
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}