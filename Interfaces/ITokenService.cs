using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos;

namespace Food_Delivery_API.Interfaces;

public interface ITokenService
{
    string CreateToken(UserDto userDto);
}