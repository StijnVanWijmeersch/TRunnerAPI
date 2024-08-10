﻿using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Domain.Groups;
public sealed class RunnerRemovedFromGroupDomainEvent(Guid runnerId, Guid groupId) : DomainEvent
{
    public Guid RunnerId { get; init; } = runnerId;
    public Guid GroupId { get; init; } = groupId;
}
