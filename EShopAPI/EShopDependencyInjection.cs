using EShopAPI.Common;
using EShopAPI.Context;
using EShopAPI.Cores.Auth.JWTs;
using EShopAPI.Cores.Auth.Services;
using EShopAPI.Cores.CompositeProducts.DAOs;
using EShopAPI.Cores.CompositeProducts.Services;
using EShopAPI.Cores.CustomVariantAttributes.DAOs;
using EShopAPI.Cores.CustomVariantAttributes.Services;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.EShopUnits.DAOs;
using EShopAPI.Cores.EShopUnits.Services;
using EShopAPI.Cores.MapUserRoles.DAOs;
using EShopAPI.Cores.MapUserRoles.Services;
using EShopAPI.Cores.Products.DAOs;
using EShopAPI.Cores.Products.Services;
using EShopAPI.Cores.ShopInventories.DAOs;
using EShopAPI.Cores.ShopInventories.Services;
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

            //LoginUserData
            services.AddScoped<LoginUserData>();

            //JWTs
            services.AddScoped<IJwtService, JwtService>();

            //ShopUsers
            services.AddScoped<IShopUserService, ShopUserService>();
            services.AddScoped<IShopUserDao, ShopUserDao>();

            //ShopRoles
            services.AddScoped<IShopRoleService, ShopRoleService>();
            services.AddScoped<IShopRoleDao, ShopRoleDao>();

            //MapUserRoles
            services.AddScoped<IMapUserRoleService, MapUserRoleService>();
            services.AddScoped<IMapUserRoleDao, MapUserRoleDao>();

            //ShopPermissions
            services.AddScoped<IShopPermissionService, ShopPermissionService>();

            //ShopInventories
            services.AddScoped<IShopInventoryService, ShopInventoryService>();
            services.AddScoped<IShopInventoryDao, ShopInventoryDao>();

            //CustomVariantAttributes
            services.AddScoped<ICustomVariantAttributeService, CustomVariantAttributeService>();
            services.AddScoped<ICustomVariantAttributeDao, CustomVariantAttributeDao>();

            //Products
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDao, ProductDao>();

            //CompositeProducts
            services.AddScoped<ICompositeProductService, CompositeProductService>();
            services.AddScoped<ICompositeProductDao, CompositeProductDao>();

            //EShopUnits
            services.AddScoped<IEShopUnitService, EShopUnitService>();
            services.AddScoped<IEShopUnitDao, EShopUnitDao>();

            return services;
        }
    }
}
