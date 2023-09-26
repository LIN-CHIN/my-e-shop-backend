using EShopAPI.Context;
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

            //EntityFrameWork Settings 
            services.AddDbContext<EShopContext>(opt => opt.UseNpgsql(
                apiSettings!.ConnectionString,
                x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "eshop")));

            //Helpers
            services.AddScoped<ILogHelper, LogHelper>();

            //Services

            return services;
        }
    }
}
