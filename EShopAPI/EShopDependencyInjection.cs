using EShopAPI.Context;
using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Cores.Auth.Services;
using EShopAPI.Cores.MapUserRoles.DAOs;
using EShopAPI.Cores.MapUserRoles.Services;
using EShopAPI.Cores.ShopPermissions.Services;
using EShopAPI.Cores.ShopRoles;
using EShopAPI.Cores.ShopRoles.DAOs;
using EShopAPI.Cores.ShopRoles.Services;
using EShopAPI.Cores.ShopUsers.DAOs;
using EShopAPI.Cores.ShopUsers.Services;
using EShopAPI.Settings;
using EShopCores.AppLogs.LogHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShopAPI
{
    /// <summary>
    /// DI注入用的class
    /// </summary>
    public static class EShopDependencyInjection
    {
        /// <summary>
        /// 新增Depndency
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfigurationRoot configurationRoot) 
        {
            //Settings 
            var apiSettings = configurationRoot.GetSection("ApiSettings").Get<ApiSettings>(c => c.BindNonPublicProperties = true);
            services.AddSingleton(apiSettings!);

            var jwtTokenSettings = configurationRoot.GetSection("JwtSettings").Get<JwtTokenSettings>(c => c.BindNonPublicProperties = true);
            services.AddSingleton(jwtTokenSettings!);

            //EntityFrameWork Settings 
            services.AddDbContext<EShopContext>(opt => opt.UseNpgsql(
                apiSettings!.ConnectionString,
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "eshop")));

            //Helpers
            services.AddScoped<ILogHelper, LogHelper>();

            //Authentication
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            //JWTs
            services.AddScoped<IJWTService, JWTService>();

            //ShopUsers
            services.AddScoped<IShopUserService, ShopUserService>();
            services.AddScoped<IShopUserDAO, ShopUserDAO>();

            //ShopRoles
            services.AddScoped<IShopRoleService, ShopRoleService>();
            services.AddScoped<IShopRoleDAO, ShopRoleDAO>();

            //MapUserRoleServices
            services.AddScoped<IMapUserRoleService, MapUserRoleService>();
            services.AddScoped<IMapUserRoleDAO, MapUserRoleDAO>();

            //ShopPermissionService
            services.AddScoped<IShopPermissionService, ShopPermissionService>();

            return services;
        }
    }
}
