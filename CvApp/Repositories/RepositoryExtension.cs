using CvApp.Repositories.Covers;
using CvApp.Repositories.Resumes;

namespace CvApp.Repositories;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfigurationSection repositoryConfigurationSection)
    {
        var options = repositoryConfigurationSection.Get<RepositoryOptions>();

        return services
            .AddSingleton<IResumeRepository>(_ => new ResumeRepository(options).InitializeAsync().GetAwaiter().GetResult())
            .AddSingleton<ICoverRepository>(_ => new CoverRepository(options).InitializeAsync().GetAwaiter().GetResult());
    }
}
