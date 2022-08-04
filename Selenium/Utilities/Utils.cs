using Selenium.Models;
using System.Text.Json;

namespace Selenium.Utilities
{
    public static class Utils
    {
        public static string GenerateRandomEmail()
        {
            return $"actum_{DateTime.Now.ToString("ddMMyyyyhhmmss")}@test.com";
        }

        public static string RandomName()
        {
            return $"Name_{DateTime.Now.ToString("ddMMyyyyhhmmss")}";
        }

    }
}
