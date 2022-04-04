﻿using FluentValidation;

namespace AlightApp.Application.Commands.Users
{
    public class CreateFileCommandHandlerValidator : AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandHandlerValidator()
        {
            RuleFor(a => a.Users).NotEmpty().WithMessage("The user information is required.");
            RuleFor(a => a.Users).Custom((user, context) =>
            {
                // We can validate for user roles, each user must have at least one role etc
                // It depends on the application design
            });
        }
    }
}
