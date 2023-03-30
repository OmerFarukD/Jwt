using Jwt.DataAccess.Contexts;
using Jwt.DataAccess.Repositories.Abstract;
using Jwt.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt.DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Sql"));
        });
        services.AddScoped<IUserDal, UserDal>();
        services.AddScoped<IUserRoleDal, UserRoleDal>();
        services.AddScoped<IRoleDal, RoleDal>();
        return services;
    }
}