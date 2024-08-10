using FluentValidation;

namespace TRunner.Modules.Groups.Application.Groups.CloseGroup;
internal sealed class CloseGroupCommandValidator : AbstractValidator<CloseGroupCommand>
{
    public CloseGroupCommandValidator()
    {
        RuleFor(c => c.GroupId).NotEmpty();
    }
}
