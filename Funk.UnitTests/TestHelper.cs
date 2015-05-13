using System.IO;

namespace Funk.UnitTests
{
    public class TestHelper
    {
        public static string LoadScript(string name)
        {
            return File.ReadAllText(string.Format("TestFiles/{0}", name));
        }
    }
}
