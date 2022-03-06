using CvApp.Models;

namespace CvApp.Repositories.Resumes;

public interface IResumeRepository
{
    Task<Resume> GetByIdAsync(string id);
}