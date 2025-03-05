using FluentValidation;
using ProjectManager.Core.Models;

namespace ProjectManager.Core.Validators
{
    internal class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(e => e.MiddleName).NotEmpty().WithMessage("Middle name is required");
            RuleFor(e => e.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format");
        }

        public async Task ValidateAndThrowAsync(CreateEmployeeDto createEmployeeDto)
        {
            var result = await ValidateAsync(createEmployeeDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
