using MediatR;
using TRunner.Common.Domain;

namespace TRunner.Common.Application.Messaging;

public interface IBaseCommand;
public interface ICommand : IRequest<Result>, IBaseCommand;
public interface ICommand<TResult> : IRequest<Result<TResult>>, IBaseCommand;
