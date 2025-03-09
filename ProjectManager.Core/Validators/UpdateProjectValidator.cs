using FluentValidation;
using ProjectManager.Core.Models;

namespace ProjectManager.Core.Validators
{
    internal class UpdateProjectValidator : AbstractValidator<UpdateProjectDto>
    {
        public UpdateProjectValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(e => e.CustomerCompany).NotEmpty().WithMessage("CustomerCompany is required");
            RuleFor(e => e.ContractorCompany).NotEmpty().WithMessage("ContractorCompany is required");
        }

        public async Task ValidateAndThrowAsync(UpdateProjectDto updateProjectDto)
        {
            var result = await ValidateAsync(updateProjectDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
