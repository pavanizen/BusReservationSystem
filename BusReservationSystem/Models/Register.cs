using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bus.DomainModels.Models;
using Microsoft.AspNetCore.Identity;

namespace BusReservationSystem.Models
{
    public class Register:IdentityUser
    {

		[Required(ErrorMessage = "Enter your Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Enter Address")]
		[RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Address in wrong format")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Enter City")]
		public string City { get; set; }

		[Required(ErrorMessage = "Enter State")]
		public string State { get; set; }

		[Required(ErrorMessage = "Enter Country")]
		public string Country { get; set; }
	
		[Required(ErrorMessage = "Enter Pin Code")]
		
		public int Pincode { get; set; }

		[Required(ErrorMessage = "Enter Age")]
		public int Age { get; set; }

		[Required(ErrorMessage = "Enter Contact Number")]
		[RegularExpression(@"^[7-9][0-9]{9}$", ErrorMessage = "Phone number format is incorrect")]
		public int ContactNumber { get; set; }

		[Required(ErrorMessage = "Enter Date of Birth")]
		//[RegularExpression("^ ([1 - 9]0[1 - 9][12][0 - 9]3[01])[- /.] ([1 - 9]0[1-9]1[012])[- /.] [0-9]{4}$"
		//	,ErrorMessage ="Invalid Date of Birth")]
		public DateTime DateOfBirth { get; set; }

        //public string Role { get; set; }

        //[Required(ErrorMessage = "Enter Customer Type")]
        //public CustomerType CustomerType { get; set; }

    }
}
