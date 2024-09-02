using FluentValidation;

namespace TRunner.Modules.Groups.Application.Groups.AddRunner;
internal sealed class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
{
    public AddMemberCommandValidator()
    {
        RuleFor(c => c.GroupId).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}
