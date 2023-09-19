using EShopCores.Enums;
using EShopCores.Errors;
using EShopCores.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddNewtonsoftJson()
        //自訂ModelState 
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

                return new OkObjectResult(new ResponseModel<List<CustomModelState>>
                {
                    Code = ResponseCodeType.ModelBindingError,
                    Message = ResponseCodeType.ModelBindingError.GetMessage(),
                    Description = ResponseCodeType.ModelBindingError.GetDescription(),
                    Content = errors
                });
            };
        });

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
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapControllers();

app.Run();
