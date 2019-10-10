using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaCarpoolApplication.Models
{
    [ModelMetadataType(typeof(UserMetadata))]
    public partial class User : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // E-mail Validation
            // Check if they entered a conestoga e-mail address.
            if (Email.Contains("@conestogac.on.ca") == false)
            {
                yield return new ValidationResult("Please enter a valid Conestoga e-mail address.",
                    new[] { nameof(Email) });
            }

            yield return ValidationResult.Success;
        }
    }
    public partial class UserMetadata
    {
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "E-mail Address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [Display(Name = "License Class")]
        public int? LicenceClassId { get; set; }

        [Display(Name = "Years of Driving Experience")]
        public int? Experience { get; set; }
    }
}
