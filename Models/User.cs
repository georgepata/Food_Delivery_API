using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Food_Delivery_API.Models.Validations;
using Microsoft.AspNetCore.Identity;
namespace Food_Delivery_API.Models;

public class User : IdentityUser
{
	[Required(ErrorMessage = $"{nameof(Phone)} is required")]
	[MaxLength(10)]
	[User_EnsureCorrectPhoneFormat]
	public string? Phone { get; set; }
	[Required]
	public string? Address { get; set; }
	public int? CityId {get; set;}
	public City? City { get; set; }
	[JsonIgnore]
	public ICollection<Order>? Orders { get; set; }
	[JsonIgnore]
	public ICollection<RatingRestaurant>? RatingRestaurants { get; set;}
}

