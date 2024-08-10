using FluentValidation;

namespace TRunner.Modules.Groups.Application.Groups.AddRunner;
internal sealed class AddRunnerCommandValidator : AbstractValidator<AddRunnerCommand>
{
    public AddRunnerCommandValidator()
    {
        RuleFor(c => c.GroupId).NotEmpty();
        RuleFor(c => c.RunnerId).NotEmpty();
    }
}
