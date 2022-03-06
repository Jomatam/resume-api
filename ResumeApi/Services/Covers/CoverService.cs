using CvApp.Repositories.Covers;

namespace CvApp.Services.Covers
{
    public class CoverService : ICoverService
    {
        private readonly ICoverRepository _coverRepository;

        public CoverService(ICoverRepository coverRepository)
        {
            _coverRepository = coverRepository;
        }

        public async Task<string> GetCoverContentAsync(string id)
        {
            var cover = await _coverRepository.GetByIdAsync(id);
            return cover.Content;
        }
    }
}
