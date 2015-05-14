using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using Funk.Core.Lexing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funk.UnitTests.Lexing.Rules
{
    [TestClass]
    public class LexRuleTests
    {
        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_Keywords()
        {
            var lexer = new Lexer();
            var tokens = lexer.Tokenize("var funk end return const").ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_Operators()
        {
            var lexer = new Lexer();
            var tokens = lexer.Tokenize("+ - * / =").ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_Whitespace()
        {
            var lexer = new Lexer();
            var tokens = lexer.Tokenize(" \r\n\t    ").ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_String()
        {
            var lexer = new Lexer();
            const string code = "\"text with spacing\"";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }
        
        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_FloatingPointNumber()
        {
            var lexer = new Lexer();
            const string code = "1.23";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }


        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_IntegerNumber()
        {
            var lexer = new Lexer();
            const string code = "23";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }


        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_SingleLineComment()
        {
            var lexer = new Lexer();
            const string code = "# this is a comment";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_OpenParenthesis()
        {
            var lexer = new Lexer();
            const string code = "(";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_ClosedParenthesis()
        {
            var lexer = new Lexer();
            const string code = ")";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_Identifier()
        {
            var lexer = new Lexer();
            const string code = "some_variable_name";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_Comment()
        {
            var lexer = new Lexer();
            const string code = "# this is a comment";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }

        [TestMethod]
        [UseReporter(typeof(WinMergeReporter))]
        public void Tokenize_MultiLineComment()
        {
            var lexer = new Lexer();
            const string code = "#! this is a multi line\r\n " +
                                "comment !#";
            var tokens = lexer.Tokenize(code).ToArray();

            Approvals.Verify(tokens.ToJson());
        }
    }
}
