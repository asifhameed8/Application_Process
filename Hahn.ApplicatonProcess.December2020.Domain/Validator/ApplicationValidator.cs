using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validator
{
    public class ApplicationValidator : AbstractValidator<Applicant>
    {
        public ApplicationValidator()
        {
           RuleFor(c => c.Name).NotEmpty()
                                .MinimumLength(5);
           RuleFor(c => c.FamilyName).NotEmpty()
                                       .MinimumLength(5);

            RuleFor(c => c.Address).MinimumLength(10);
            RuleFor(c => c.EmailAddress).EmailAddress().WithMessage("A valid email is required");
            RuleFor(c => c.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(60).WithMessage("Age must between 20 to 60");
            RuleFor(c => c.Hired).NotNull();
        }
    }
}
