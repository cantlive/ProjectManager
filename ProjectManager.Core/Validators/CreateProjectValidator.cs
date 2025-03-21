﻿using FluentValidation;
using ProjectManager.Core.Models;

namespace ProjectManager.Core.Validators
{
    internal class CreateProjectValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p => p.CustomerCompany).NotEmpty().WithMessage("CustomerCompany is required");
            RuleFor(p => p.ContractorCompany).NotEmpty().WithMessage("ContractorCompany is required");
            RuleFor(p => p.ProjectManagerId).NotEqual(Guid.Empty).WithMessage("Project manager is required");
        }

        public async Task ValidateAndThrowAsync(CreateProjectDto createProjectDto)
        {
            var result = await ValidateAsync(createProjectDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
