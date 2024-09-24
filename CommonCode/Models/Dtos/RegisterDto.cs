
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CommonCode.Models.Dtos
{
    public class RegisterDto
    {
        //
        // Summary:
        //     Gets or sets the user name for this user.
        [ProtectedPersonalData]
        [Required(ErrorMessage = "User Name can't be blank")]
        [Length(3, 256, ErrorMessage = "User name should have 3-256 characters")]
        [RegularExpression("^[a-zA-Z0-9\\-_]*$", ErrorMessage = "User name can contain only alphanumeric and '-', '_' characters and can't have space.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Person Name can't be blank")]
        public string PersonName { get; set; } = string.Empty;

        //
        // Summary:
        //     Gets or sets the email address for this user.
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already is use")]
        [ProtectedPersonalData]
        public string Email { get; set; } = string.Empty;

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Phone number can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain digits only")]
        [Length(10, 10, ErrorMessage = "Phone no. should be exactly of 10 characters")]
        public string PhoneNumber { get; set; } = string.Empty;


        [ProtectedPersonalData]
        [Required(ErrorMessage = "Password can't be blank")]
        [Length(8, 16, ErrorMessage = "Password should be of 8-16 characters")]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
