using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Interfaces;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Food_Delivery_API.Services;

[Route("api/controller")]
[ApiController]
public class TokenService : ITokenService
{
    private static readonly TimeSpan DefaultTokenLifetime = TimeSpan.FromHours(8);
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _symmetricSecurityKey;
    private readonly UserManager<User> _userManager;
    public TokenService(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
        _userManager = userManager;
    }
    public string CreateToken(UserDto userDto, TimeSpan? tokenLifetime = null) 
    {
        var claims = new List<Claim>(){
            new Claim(JwtRegisteredClaimNames.Email, userDto.Email),
            new Claim(JwtRegisteredClaimNames.Name, userDto.Name),
            new Claim("address", userDto.Address),
            new Claim("phone_number", userDto.Phone),
            new Claim("userId", userDto.UserId),
            new Claim("role", userDto.Role)
        };


        var creds = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(tokenLifetime ?? DefaultTokenLifetime),
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"], 
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescription);

        var jwt = tokenHandler.WriteToken(token);

        return jwt;
    }
}
