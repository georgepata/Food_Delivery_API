using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Food_Delivery_API.Models.Validations;
using Microsoft.AspNetCore.Identity;
namespace Food_Delivery_API.Models;

public class User
{
	public int UserId { get; set; }

	[Required]
	[MaxLength(50)]
	public string? Name { get; set; }

	[Required]
	[MaxLength(20)]
	public string? Password { get; set;}

	[Required]
	[MaxLength(50)]
	[User_EnsureCorrectEmailFormat]
	public string? Email { get; set; }

	[Required(ErrorMessage = $"{nameof(Phone)} is required")]
	[MaxLength(10)]
	[User_EnsureCorrectPhoneFormat]
	public string? Phone { get; set; }

	[Required]
	public string? Address { get; set; }
	public City? City { get; set; }
	public ICollection<Order>? Orders { get; set; }
	public ICollection<RatingRestaurant>? RatingRestaurants { get; set;}
}

