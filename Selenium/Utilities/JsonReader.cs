using Newtonsoft.Json.Linq;

namespace Selenium.Utilities
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public string extractData(string tokenName)
        {
            var userData = File.ReadAllText("UserData.json");
            var jsonObject = JToken.Parse(userData);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

    }
}
