namespace TRunner.API.Extensions;

internal static class ConfigurationExtensions
{
    public static void AddModulesConfiguration(
        this IConfigurationBuilder configurationBuilder,
        string[] modules)
    {
        foreach (string module in modules)
        {
            configurationBuilder.AddJsonFile($"modules.{module}.json", false, true);
            configurationBuilder.AddJsonFile($"modules.{module}.Development.json", true, true);
        }
    }
}
