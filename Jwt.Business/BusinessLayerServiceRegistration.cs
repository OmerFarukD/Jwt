using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwt.Business.Abstract;
using Jwt.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt.Business
{
    public static class BusinessLayerServiceRegistration
    {

        public static IServiceCollection AddBusinessDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserService,UserManager>();
            service.AddScoped<IAuthService, AuthManager>();
            return service;
        }
    }
}
