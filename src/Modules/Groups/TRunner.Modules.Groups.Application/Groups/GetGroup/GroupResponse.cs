namespace TRunner.Modules.Groups.Application.Groups.GetGroup;
public sealed record GroupResponse(
    Guid Id,
    string Name,
    string Description,
    int Size,
    int RunnersCount,
    Guid OwnerId)
{
    // Add runners to the group
}
