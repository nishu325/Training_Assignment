using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.Models
{
    public class Employee
    {
        /*Id generate and increament automatically into database.*/
        public int Id { get; set; }

        /*For taking employee name*/
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /*For taking employee email*/
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Enter valid Emial-id")]
        public string Email { get; set; }

        /*For taking employee password */
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Password length of 8 digit and contain Uppercase,lowercase,special symbol and digit")]
        public string Password { get; set; }

        /*For taking employee mobile number*/
        [Required(ErrorMessage = "Enter 10 digit valid Indian mobile number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "Enter 10 digit valid Indian mobile number.")]
        public string Phone { get; set; }

        /*For taking employee image*/
        [Required(ErrorMessage = "Enter valid image")]
        [FileExtensions(Extensions = "png,jpeg,jpg", ErrorMessage = "Image should be in .jpg or .jpeg or .png format")]
        public string ImagePath { get; set; }

        /*For taking employee age*/
        [Required(ErrorMessage = "Age must be in between 18 to 100 years !")]
        [Range(18, 100)]
        public int Age { get; set; }

        /*
         
         For taking employee total years of experience.
         This is custom validation for validate this field. 

         */
        [Required]
        [SourceControlFinalAssignment.CustomAttribute.MinExperience(2)]
        public float Experience { get; set; }
    }
}