namespace TRunner.Modules.Groups.Application.Groups.GetGroups;
public sealed record GroupResponse(
    Guid Id,
    string Name,
    string Description,
    int Size,
    int RunnersCount,
    Guid OwnerId
    );
