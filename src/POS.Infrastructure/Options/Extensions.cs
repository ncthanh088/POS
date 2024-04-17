using Microsoft.Extensions.Configuration;

namespace POS.Infrastructure.Options;

public static class Extensions
{
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        // TODO: Try missing the section Name when start the application, then catching the error.
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}
