using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Implementations;
using WebApi.Business.src.Shared;
using WebApi.Domain.src.Abstractions;
using WebApi.WebApi.src.Database;
using WebApi.WebApi.src.RepoImplementations;

var builder = WebApplication.CreateBuilder(args);

//Add AutoMapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add db context
builder.Services.AddDbContext<DatabaseContext>();

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
        Description = "Bearer token authentication",
        Name = "Authentication",
        In = ParameterLocation.Header
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

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
        ValidIssuer = "ecommerce-backend",
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secret-key-is-my-goal-to-secure-everything")),
        ValidateIssuerSigningKey = true
    };
    
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
