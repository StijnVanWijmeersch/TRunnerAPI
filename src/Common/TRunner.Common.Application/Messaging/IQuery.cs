using MediatR;
using TRunner.Common.Domain;

namespace TRunner.Common.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
