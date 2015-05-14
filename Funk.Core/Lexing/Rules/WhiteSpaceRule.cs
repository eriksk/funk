using System.Linq;

namespace Funk.Core.Lexing.Rules
{
    public class WhiteSpaceRule : LexRule
    {
        private readonly char[] _whiteSpaceChars;

        public WhiteSpaceRule()
        {
            _whiteSpaceChars = new[]
            {
                ' ',
                '\n',
                '\r',
                '\t'
            };
        }

        public override bool Match(string code, int index)
        {
            var c = code[index];
            return _whiteSpaceChars.Contains(c);
        }

        public override Token GetToken(string code, int index)
        {
            var c = code[index].ToString();
            return new Token(1, "whitespace", c);
        }
    }
}