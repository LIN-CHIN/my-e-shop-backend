using EShopCores.AppLogs.LogHelpers;

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
        /// <returns></returns>
        public static IServiceCollection AddDependency(this IServiceCollection services) 
        {
            services.AddScoped<ILogHelper, LogHelper>();

            return services;
        }
    }
}
