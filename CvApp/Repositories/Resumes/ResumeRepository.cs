using CvApp.Models;
using Microsoft.Azure.Cosmos;

namespace CvApp.Repositories.Resumes;

public class ResumeRepository : BaseRepository<ResumeRepository, Resume>, IResumeRepository
{
    public ResumeRepository(RepositoryOptions options)
    : base(options)
    {
    }

    protected override string ContainerName => "Resumes";

    public Task<Resume> GetByIdAsync(string id) => GetByIdAsync(id, PartitionKey.None);
}