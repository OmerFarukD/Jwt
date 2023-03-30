namespace Jwt.Entities.Dtos;

public sealed record UserForRegisterDto(string FirstName, string LastName, string Email, string UserName, string Password, int RoleId);