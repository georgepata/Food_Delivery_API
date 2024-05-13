using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Delivery_API.Dtos.User.City;
using Food_Delivery_API.Models;

namespace Food_Delivery_API.Interfaces;

public interface ICityRepository
{
    City GetCityById(int id);
    bool AddCity(City cityDto);
    bool UpdateCity(int id, CityDto cityDto);
    bool DeleteCity(int id);
}