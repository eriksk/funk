using System;
using System.Text.RegularExpressions;

namespace Funk.Core.Lexing.Rules
{
    public class IdentifierRule : LexRule
    {
        private readonly string _regex;
        
        public IdentifierRule()
        {
            _regex = @"\A([a-zA-Z|_]*)";
        }

        public override bool Match(string code, int index)
        {
            return Regex.IsMatch(code.Substring(index), _regex) && Regex.Match(code.Substring(index), _regex).Value.Length > 0;
        }

        public override Token GetToken(string code, int index)
        {
            var value = Regex.Match(code.Substring(index), _regex).Value;
        
            return new Token(value.Length, "identifier", value);
        }
    }
}
