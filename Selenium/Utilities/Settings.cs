using Microsoft.Extensions.Configuration;

namespace Selenium.Utilities
{
    public class Settings
    {
        public static IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

        public static string HomePageUrl => Config.GetSection("Url")["HomePageUrl"];
        public static string SignInPageUrl => Config.GetSection("Url")["SignInPageUrl"];
        public static string ContactUsPageUrl => Config.GetSection("Url")["ContactUsPageUrl"];
    }
}
