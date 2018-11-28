using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.Validators
{
    public class Min18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birth == null)
                return new ValidationResult("Birthdade is required.");

            var age = DateTime.Today.Year - customer.Birth.Value.Year;

            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Costumer should be at least 18 years old to be a membership");
        }
    }
}