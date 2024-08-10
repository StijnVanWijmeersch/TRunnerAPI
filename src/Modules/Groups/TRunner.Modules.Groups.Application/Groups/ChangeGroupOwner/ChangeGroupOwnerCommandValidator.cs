using FluentValidation;

namespace TRunner.Modules.Groups.Application.Groups.ChangeGroupOwner;
internal sealed class ChangeGroupOwnerCommandValidator : AbstractValidator<ChangeGroupOwnerCommand>
{
    public ChangeGroupOwnerCommandValidator()
    {
        RuleFor(c => c.GroupId).NotEmpty();
        RuleFor(c => c.NewOwnerId).NotEmpty();
    }
}
