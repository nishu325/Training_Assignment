using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1.Models
{
    public class User
    {
        /*Name field with maximum length is 20*/
        [Required(ErrorMessage ="Your name should contain at most 20 character")]
        [MaxLength(20)]
        public string Name { get; set; }


        /*This field is used for to get the user introduction*/
        [Required]
        [DisplayName("Please introduce your self")]
        public string Intro { get; set; }


        /*This is used for to get user Email address*/
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }


        /*This is used for to get user confirm Email address*/
        [Required(ErrorMessage ="Enter confirm email id")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Compare("Email",ErrorMessage ="Entered email address is not mathced with previous email address")]
        public string ConfirmEmail { get; set; }
        

        /*This is used for to get user password */
        [StringLength(15,MinimumLength =8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        /*
         This is used for get total experience of user 
         This is used custom validation for validation of experience
        */
        [DisplayName("Enter your total experience")]
        [SourceControlAssignment1.CustomAttribute.MinExperience(2)]
        public int Experience { get; set; }

        /*This field is used for take user phone nmber.*/
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "Enter valid Phone number")]
        public string Phone { get; set; }
    }
}