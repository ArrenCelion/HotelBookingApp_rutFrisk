using FluentValidation;
using HotelBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Utilities.Validation
{
    public class GuestValidator : AbstractValidator<Guest>
    {
        public GuestValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MinimumLength(2).WithMessage("First Name must be at least 2 characters.")
                .Matches(@"^[a-zA-ZåäöÅÄÖ]+$").WithMessage("First Name can only contain letters.")
                .NotEqual("Bajskorv").WithMessage("First Name cannot be Bajskorv.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MinimumLength(2).WithMessage("Last Name must be at least 2 characters.")
                .Matches(@"^[a-zA-ZåäöÅÄÖ]+$").WithMessage("Last Name can only contain letters.");

            RuleFor(c => c.Email)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Invalid email format.");
               
            RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^0").WithMessage("Phone number must begin with 0.")
            .Matches(@"^\d+$").WithMessage("Phone number must contain only numbers.")
            .Length(10, 15).WithMessage("Phone number must be between 10 and 15 digits.");

            RuleFor(c => c.DateOfBirth)
               .NotEmpty().WithMessage("Date of Birth is required.")
               .Must(BeAtLeast18YearsOld).WithMessage("Guests must be at least 18 years old.");
            
            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MinimumLength(2).WithMessage("Address must be at least 2 characters.");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Postal Code is required.")
                .Matches(@"^\d+$").WithMessage("Postal Code must contain only numbers.");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City is required.");
                

        }
        private bool BeAtLeast18YearsOld(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now.AddYears(-18);
        }
    }
}
