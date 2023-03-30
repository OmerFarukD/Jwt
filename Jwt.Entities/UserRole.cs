using Jwt.Core.Entities;

namespace Jwt.Entities;

public class UserRole : IEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public int Id { get; set; }
}