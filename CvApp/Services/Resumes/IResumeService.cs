using CvApp.Models;

namespace CvApp.Services.Resumes;

public interface IResumeService
{
    Task<Resume> GetByCoverIdAsync(string coverId);
}
