using EShopAPI.Middlewares;
using EShopCores.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using Serilog.Events;
using Serilog;
using Serilog.Exceptions;
using EShopAPI;
using EShopCores.Responses;
using EShopAPI.Context;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers()
        .AddNewtonsoftJson()
        //Custom ModelState 
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Select(s => new CustomModelState
                    {
                        Key = s.Key,
                        ErrorMessage = s.Value?.Errors
                            .Select(x =>
                            {
                                if (string.IsNullOrEmpty(x.ErrorMessage))
                                {
                                    return x.Exception?.Message;
                                }
                                else
                                {
                                    return x.ErrorMessage;
                                }
                            }).SingleOrDefault()
                    })
                    .ToList();

                return new OkObjectResult(new GenericResponse<List<CustomModelState>>
                {
                    Code = ResponseCodeType.ModelBindingError,
                    Message = ResponseCodeType.ModelBindingError.GetMessage(),
                    Description = ResponseCodeType.ModelBindingError.GetDescription(),
                    Content = errors
                });
            };
        });

    //Dependency Injection
    builder.Services.AddDependency(builder.Configuration);
    
    //NSwag Settings
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddOpenApiDocument(settings =>
    {
        settings.DocumentName = "eShop-API";  //預設為V1
        settings.Title = "eShop API";
        settings.Version = "1.0.0";
        settings.Description = "集合所有eShop API";
        settings.AddSecurity("Bearer Token", Enumerable.Empty<string>(),
            new OpenApiSecurityScheme()
            {
                Type = OpenApiSecuritySchemeType.Http,
                In = OpenApiSecurityApiKeyLocation.Header,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Put your JWT token here",
                Name = "Authorization"
            }
        );

        //讓Controller可以直接加上註解，就能夠顯示在swagger畫面中
        settings.UseControllerSummaryAsTagDescription = true;
    });

    //Log Settings
    builder.Host.UseSerilog();
    Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Information()
       .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
       .Enrich.FromLogContext()
       .Enrich.WithExceptionDetails()
       .WriteTo.File($"Logs/.txt", rollingInterval: RollingInterval.Day)
       .CreateLogger();

    var app = builder.Build();

    // Entity Framework migrate on startup
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<EShopContext>();
        context.Database.Migrate();
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi(options =>
        {

        });

        app.UseSwaggerUi3(options =>
        {

        });

        app.UseReDoc(options =>
        {
            options.Path = "/redoc";
        });
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    //Custom Middleware
    app.UseMiddleware<LogMiddleware>();
    app.UseMiddleware<ExceptionMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex.ToString(), "Stopped program because of exception");
    throw;
}
finally
{
    Log.CloseAndFlush();
}

