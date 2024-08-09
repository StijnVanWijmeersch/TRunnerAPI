using FluentValidation;

namespace TRunner.Modules.Groups.Application.Groups.CreateGroup;
internal sealed class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty().MaximumLength(255);
        RuleFor(c => c.Size).GreaterThan(0);
        RuleFor(c => c.OwnerId).NotEmpty();
    }
}
