using Funk.Core.Interpreting;
using Funk.Core.Lexing;
using Funk.Core.Parsing;

namespace Funk.Core
{
    public class Funk
    {
        private readonly Lexer _lexer;
        private readonly Parser _parser;
        private readonly Interpreter _interpreter;

        public Funk()
        {
            _lexer = new Lexer();
            _interpreter = new Interpreter();
            _parser = new Parser();
        }

        public void Run(string code)
        {
            var tokens = _lexer.Tokenize(code);
            var syntaxTree = _parser.Parse(tokens);
            _interpreter.Run(syntaxTree);
        }
    }
}
