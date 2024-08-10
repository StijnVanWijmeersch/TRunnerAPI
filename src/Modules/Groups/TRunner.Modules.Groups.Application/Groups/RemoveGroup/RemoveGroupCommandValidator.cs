using FluentValidation;

namespace TRunner.Modules.Groups.Application.Groups.RemoveGroup;
internal sealed class RemoveGroupCommandValidator : AbstractValidator<RemoveGroupCommand>
{
    public RemoveGroupCommandValidator()
    {
        RuleFor(c => c.GroupId).NotEmpty();
    }
}
