﻿using FluentValidation;
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
                .Matches(@"^[a-zA-ZåäöÅÄÖ]+$").WithMessage("First Name can only contain letters.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MinimumLength(2).WithMessage("Last Name must be at least 2 characters.")
                .Matches(@"^[a-zA-ZåäöÅÄÖ]+$").WithMessage("Last Name can only contain letters.");

            // Förklaring av email regex
            //^[^@\s]+: Börjar med en eller flera tecken som inte är @ eller mellanslag.
            //@: Kräver exakt ett @.
            //[^@\s]+\.: Kräver minst ett tecken före en punkt.
            //[^@\s]+$: Kräver minst ett tecken efter punkten.Förklaring av regex
            RuleFor(c => c.Email)
               .NotEmpty().WithMessage("Email is required.")
               .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Invalid email format.");

            RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^0").WithMessage("Phone number must begin with 0.")
            .Matches(@"^\d+$").WithMessage("Phone number must contain only numbers.")
            .Length(10, 15).WithMessage("Phone number must be between 10 and 15 digits.");

            RuleFor(c => c.DateOfBirth)
               .NotEmpty().WithMessage("Date of Birth is required.")
               .Must(BeAtLeast18YearsOld).WithMessage("Guests must be at least 18 years old.");


        }
        private bool BeAtLeast18YearsOld(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now.AddYears(-18);
        }
    }
}
