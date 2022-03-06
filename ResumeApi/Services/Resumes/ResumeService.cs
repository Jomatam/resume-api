using CvApp.Models;
using CvApp.Repositories.Covers;
using CvApp.Repositories.Exceptions;
using CvApp.Repositories.Resumes;
using Microsoft.Extensions.Options;

namespace CvApp.Services.Resumes;

public class ResumeService : IResumeService
{
    private readonly IResumeRepository _resumeRepository;
    private readonly ICoverRepository _coverRepository;
    private readonly ResumeServiceOptions _options;

    public ResumeService(
        IResumeRepository resumeRepository,
        ICoverRepository coverRepository,
        IOptions<ResumeServiceOptions> options
       )
    {
        _resumeRepository = resumeRepository;
        _coverRepository = coverRepository;
        _options = options.Value;
    }

    public async Task<Resume> GetByCoverIdAsync(string coverId)
    {
        var resume = await CoverExistsAsync(coverId)
            ? await _resumeRepository.GetByIdAsync(_options.ResumeId)
            : throw new EntityNotFoundException(coverId);

        resume.Id = coverId;
        return resume;
    }

    private async Task<bool> CoverExistsAsync(string coverId)
    {
        try
        {
            _ = await _coverRepository.GetByIdAsync(coverId);
            return true;
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
    }
}
