﻿using TRunner.Domain.Abstractions;

namespace TRunner.Domain.Users;
public sealed class UserCreatedDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; init; } = userId;
}
