using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Food_Delivery_API.Services;

public class TokenService : ITokenService
{
    private TimeSpan TokenLifetime = TimeSpan.FromDays(8);
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _symettricSecurityKey;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _symettricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
    }
    public string CreateToken(UserDto userDto)
    {
        var claims = new List<Claim>(){
            new Claim(JwtRegisteredClaimNames.Email, userDto.Email),
            new Claim(JwtRegisteredClaimNames.Name, userDto.Name),
            new Claim("phone_number", userDto.Phone)
        };

        var creds = new SigningCredentials(_symettricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenLifetime),
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT: Audience"],
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }
}