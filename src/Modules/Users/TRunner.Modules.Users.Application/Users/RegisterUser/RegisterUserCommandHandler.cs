using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;
using TRunner.Modules.Users.Application.Abstractions.Data;
using TRunner.Modules.Users.Domain.Users;

namespace TRunner.Modules.Users.Application.Users.RegisterUser;
internal sealed class RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.UserName, request.Email);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
