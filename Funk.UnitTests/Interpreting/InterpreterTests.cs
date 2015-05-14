using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funk.UnitTests.Interpreting
{
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        [DeploymentItem("TestFiles/hello_world.fk", "TestFiles")]
        public void HelloWorld_PrintsHelloWorld()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
         
            var funk = new Core.Funk();
            funk.Run(TestHelper.LoadScript("hello_world.fk"));

            Assert.AreEqual("Hello World", writer.ToString());
        }
    }
}
