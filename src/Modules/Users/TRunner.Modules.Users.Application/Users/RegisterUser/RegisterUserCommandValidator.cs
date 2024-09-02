using FluentValidation;

namespace TRunner.Modules.Users.Application.Users.RegisterUser;
internal class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.UserName)
            .MinimumLength(3)
            .MaximumLength(50)
            .NotEmpty();
    }
}
