using CvApp.Services.Covers;
using CvApp.Services.Resumes;

namespace CvApp.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfigurationSection resumeConfigurationSection)
    {
        services
            .AddOptions<ResumeServiceOptions>()
            .Bind(resumeConfigurationSection);

        return services
            .AddSingleton<IResumeService, ResumeService>()
            .AddSingleton<ICoverService, CoverService>();
    }
}
