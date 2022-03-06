namespace CvApp.Services.Covers
{
    public interface ICoverService
    {
        Task<string> GetCoverContentAsync(string id);
    }
}
