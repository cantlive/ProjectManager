﻿using FluentValidation;
using ProjectManager.Core.Models;

namespace ProjectManager.Core.Validators
{
    internal class CreateProjectValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(e => e.CustomerCompany).NotEmpty().WithMessage("CustomerCompany is required");
            RuleFor(e => e.ContractorCompany).NotEmpty().WithMessage("ContractorCompany is required");
            RuleFor(p => p.StartDate).LessThanOrEqualTo(p => p.EndDate).WithMessage("Start date cannot be after end date");
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
