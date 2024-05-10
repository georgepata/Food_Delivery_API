using Food_Delivery_API.Data;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Food_Delivery_API.Repositories;
using Food_Delivery_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
  
builder.Services.AddDbContext<FoodDeliveryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FoodDeliveryContext")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<ITokenService, TokenService>();

// builder.Services.AddIdentity<User, IdentityRole>()
//         .AddEntityFrameworkStores<FoodDeliveryContext>()
//         .AddDefaultTokenProviders();

// builder.Services.AddScoped<UserManager<User>>();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = 
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme = 
    options.DefaultSignInScheme = 
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
    };
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

