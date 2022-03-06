using CvApp.Models;
using Microsoft.Azure.Cosmos;

namespace CvApp.Repositories.Covers;

public class CoverRepository : BaseRepository<CoverRepository, Cover>, ICoverRepository
{
    public CoverRepository(RepositoryOptions options)
        : base(options)
    {
    }

    protected override string ContainerName => "Covers";

    public Task<Cover> GetByIdAsync(string id) => GetByIdAsync(id, PartitionKey.None);
}
