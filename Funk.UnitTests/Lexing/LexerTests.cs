using System.Linq;
using Funk.Core;
using Funk.Core.Lexing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funk.UnitTests.Lexing
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        [DeploymentItem("TestFiles/hello_world.fk", "TestFiles")]
        public void Tokenize_HelloWorld()
        {
            AssertTokens("hello_world.fk", new[]
            {
                "print", "Hello World"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/variable_assignment.fk", "TestFiles")]
        public void Tokenize_VariableAssignment()
        {
            AssertTokens("variable_assignment.fk", new[]
            {
                "var", "my_var", "=", "Hello World"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/constant_declaration.fk", "TestFiles")]
        public void Tokenize_ConstantDeclarations()
        {
            AssertTokens("constant_declaration.fk", new[]
            {
                "const", "pi", "=", "3.141516",
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/function_declaration.fk", "TestFiles")]
        public void Tokenize_FunctionDeclaration()
        {
            AssertTokens("function_declaration.fk", new[]
            {
                "funk", "multiply", "(", "a", ",", "b", ")",
                "end"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/function_declaration_and_call.fk", "TestFiles")]
        public void Tokenize_FunctionDeclaration_AndCall()
        {
            AssertTokens("function_declaration_and_call.fk", new[]
            {
                "funk", "multiply", "(", "a", ",", "b", ")",
                "return", "a", "+", "b",
                "end",
                "multiply", "(", "3", ",", "8", ")"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/ops_add.fk", "TestFiles")]
        public void Tokenize_Op_Add()
        {
            AssertTokens("ops_add.fk", new[]
            {
                "3", "+", "9"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/ops_sub.fk", "TestFiles")]
        public void Tokenize_Op_Sub()
        {
            AssertTokens("ops_sub.fk", new[]
            {
                "3", "-", "9"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/ops_div.fk", "TestFiles")]
        public void Tokenize_Op_Div()
        {
            AssertTokens("ops_div.fk", new[]
            {
                "3", "/", "9"
            });
        }
        
        [TestMethod]
        [DeploymentItem("TestFiles/ops_mul.fk", "TestFiles")]
        public void Tokenize_Op_Mul()
        {
            AssertTokens("ops_mul.fk", new[]
            {
                "3", "*", "9"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/single_line_comment.fk", "TestFiles")]
        public void Tokenize_SingleLineComment()
        {
            AssertTokens("single_line_comment.fk", new[]
            {
                " hello man what up yo"
            });
        }

        [TestMethod]
        [DeploymentItem("TestFiles/multi_line_comment.fk", "TestFiles")]
        public void Tokenize_MultiLineComment()
        {
            AssertTokens("multi_line_comment.fk", new[]
            {
                " hello man what up yo\r\n"+
                "	this comment spans multiple lines\r\n"+
                "\r\n" +
                "	pretty cool huh\r\n"
            });
        }

        private void AssertTokens(string fileName, string[] expected)
        {
            var code = TestHelper.LoadScript(fileName);
            var lexer = new Lexer();
            var tokens = lexer.Tokenize(code).Where(x => x.Command != "whitespace").Select(x => x.Value).ToArray();

            CollectionAssert.AreEqual(expected, tokens, string.Join(" ", tokens));
        }
    }
}
