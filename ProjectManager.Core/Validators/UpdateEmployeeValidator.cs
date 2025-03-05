using FluentValidation;
using ProjectManager.Core.Models;

namespace ProjectManager.Core.Validators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(e => e.MiddleName).NotEmpty().WithMessage("Middle name is required");
            RuleFor(e => e.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format");
        }

        public async Task ValidateAndThrowAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var result = await ValidateAsync(updateEmployeeDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
