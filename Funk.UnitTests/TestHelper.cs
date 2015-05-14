using System.IO;
using Newtonsoft.Json;

namespace Funk.UnitTests
{
    public class TestHelper
    {
        public static string LoadScript(string name)
        {
            return File.ReadAllText(string.Format("TestFiles/{0}", name));
        }
    }

    public static class JSonExt
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
