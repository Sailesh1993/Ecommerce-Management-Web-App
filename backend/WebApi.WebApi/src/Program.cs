using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Implementations;
using WebApi.Business.src.Shared;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.Middleware;
using WebApi.WebApi.src.Database;
using WebApi.WebApi.src.RepoImplementations;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
var npgsqlBuilder = new NpgsqlDataSourceBuilder(connectionString);
npgsqlBuilder.MapEnum<Role>();
npgsqlBuilder.MapEnum<OrderStatus>();
var modifiedConnectionString = npgsqlBuilder.Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.AddInterceptors(new TimeStampInterceptor());
    options.UseNpgsql(modifiedConnectionString)
           .UseSnakeCaseNamingConvention();
});

//Add AutoMapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add services DI
builder.Services
.AddScoped<IUserRepo, UserRepo>()
.AddScoped<IUserService, UserService>()
.AddScoped<IAuthService, AuthService>()
.AddScoped<IProductRepo, ProductRepo>()
.AddScoped<IProductService, ProductService>()
.AddScoped<ICategoryRepo, CategoryRepo>()
.AddScoped<ICategoryService, CategoryService>()
.AddScoped<IOrderRepo, OrderRepo>()
.AddScoped<IOrderService, OrderService>()
.AddScoped<IOrderProductRepo, OrderProductRepo>()
.AddScoped<IOrderProductService, OrderProductService>()
.AddScoped<ICartRepo, CartRepo>()
.AddScoped<ICartService, CartService>()
.AddScoped<ICartItemRepo, CartItemRepo>()
.AddScoped<ICartItemService, CartItemService>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add policy based requirement handler to service
builder.Services.
AddSingleton<ErrorHandlerMiddleware>();

//Config route
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

//Config the authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "backup-my-private-issuer-from-everything-SecretIssuer",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "backup-my-private-secure-from-everything-SecretKey")),
    };
    
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000") // React app's URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// CORS error
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
