using System.Data.Common;
using Dapper;
using TRunner.Common.Application.Data;
using TRunner.Common.Application.Messaging;
using TRunner.Common.Domain;

namespace TRunner.Modules.Groups.Application.Groups.GetGroups;
internal class GetGroupsQueryHandler(
    IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetGroupsQuery, IReadOnlyCollection<GroupResponse>>
{
    public async Task<Result<IReadOnlyCollection<GroupResponse>>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string query =
            $"""
            SELECT 
                g.Id as {nameof(GroupResponse.Id)},
                g.Name as {nameof(GroupResponse.Name)},
                g.Description as {nameof(GroupResponse.Description)},
                g.Size as {nameof(GroupResponse.Size)},
                0 as {nameof(GroupResponse.RunnersCount)},
                g.OwnerId as {nameof(GroupResponse.OwnerId)}
            FROM groups.Groups g
            """;


        List<GroupResponse> groups = (await connection.QueryAsync<GroupResponse>(query, request)).AsList();

        return groups;
    }
}
