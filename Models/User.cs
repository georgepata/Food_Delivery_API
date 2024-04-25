using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Food_Delivery_API.Models.Validations;
namespace Food_Delivery_API.Models;

public class User
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int UserId { get; set; }

	[Required]
	[MaxLength(50)]
	public string? Name { get; set; }

	[Required]
	[MaxLength(50)]
	[User_EnsureCorrectEmailFormat]
	public string Email { get; set; }

	[Required(ErrorMessage = $"{nameof(Phone)} is required")]
	[MaxLength(10)]
	[User_EnsureCorrectPhoneFormat]
	public string Phone { get; set; }

	[Required]
	public string Address { get; set; }
	public City? City { get; set; }
	public ICollection<Order>? Orders { get; set; }
	public ICollection<RatingRestaurant>? RatingRestaurants { get; set;}
}

