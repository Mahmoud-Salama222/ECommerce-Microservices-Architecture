using Discount.Application.commends;
using FluentValidation;
using Ordering.Application.Commends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Validaitoer
{
    public class CheckoutOrderCommendValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommendValidator()
        {
            RuleFor(o => o.UserName)
                .NotEmpty()
                .WithMessage("{UserName} is required")
                .NotNull()
                .MaximumLength(70)
                .WithMessage("{UserName} must not exceed 70 characters");

            RuleFor(o => o.TotalPrice)
                .NotEmpty()
                .WithMessage("{TotalPrice} is required")
                .NotNull()
                .GreaterThan(-1)
                .WithMessage("{TotalPrice} should not be -ve");


            RuleFor(o => o.EmailAddress)
                .NotEmpty()
                .WithMessage("{EmailAddress} is required");

            RuleFor(o => o.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("{FirstName} is required");

            RuleFor(o => o.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("{LastName} is required");

        }
    }
}
    
