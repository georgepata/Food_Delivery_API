using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;
using Food_Delivery_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Food_Delivery_API.Services;

[Route("api/controller")]
[ApiController]
public class TokenService : ControllerBase
{
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _symmetricSecurityKey;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
    }
    [HttpPost("token")]
    public IActionResult CreateToken(UserDto userDto)
    {
        var claims = new List<Claim>(){
            new Claim(JwtRegisteredClaimNames.Email, userDto.Email),
            new Claim(JwtRegisteredClaimNames.Name, userDto.Name),
            new Claim("address", userDto.Address),
            new Claim("phone_number", userDto.Phone)
        };


        var creds = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenLifetime),
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"], // Corrected typo here
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescription);

        var jwt = tokenHandler.WriteToken(token);

        return Ok(jwt);
    }
}
