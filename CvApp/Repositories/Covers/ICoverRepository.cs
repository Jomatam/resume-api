using CvApp.Models;

namespace CvApp.Repositories.Covers;

public interface ICoverRepository
{
    Task<Cover> GetByIdAsync(string id);
}
