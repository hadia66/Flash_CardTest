
//using AgileObjects.ReadableExpressions;
using AgileObjects.ReadableExpressions;
using Flash_Card;
using Flash_Card.Repository;
using Flash_Card.Repository.IRepository;
using Flash_Card.Service;
using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Localization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();
//add services to connect database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductservice, ProductService>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Auth", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer Scheme(\"bearer{token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//add authentication setting

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(x =>
//                {
//                    x.TokenValidationParameters = new TokenValidationParameters()
//                    {
//                        IssuerSigningKey = new SymmetricSecurityKey(
//                            Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
//                        ValidateIssuerSigningKey = true,
//                        ValidateIssuer = false,
//                        ValidateAudience = false,
//                    };
//                });
builder.Services.AddLocalization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
//builder.Services.AddSingleton<TranslationClient>(x =>
//    TranslationClient.Create(
//        new TranslationSettings { ApiKey = "AIzaSyC69tYuAo11VZ44WcgUE2yefAZ5r3jmZNU" }));
//builder.Services.AddMvc()
//    .AddDataAnnotationsLocalization(options =>
//    {
//        options.DataAnnotationLocalizerProvider = (type, factory) =>
//            factory.Create(typeof(JsonStringLocalizerFactory));
//    });

//builder.Services.AddSingleton<TranslationClient>(x =>
//    TranslationClient.Create(
//        new TranslationSettings
//        {
//            ApiKey = "AIzaSyC69tYuAo11VZ44WcgUE2yefAZ5r3jmZNU",
//        })) ;

//builder.Services.AddScoped<TranslationService>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG"),
        new CultureInfo("de-DE")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);
    options.SupportedCultures = supportedCultures;
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});


app.UseHttpsRedirection();

var supportedCultures = new[] { "en-US", "ar-EG", "de-DE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
app.UseAuthorization();

app.MapControllers();

app.Run();
