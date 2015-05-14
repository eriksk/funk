using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Funk.Core.Lexing.Rules
{
    public class StringRule : LexRule
    {
        private readonly string _regex;

        public StringRule()
        {
            _regex = "\\A\"(.*)\"";
        }

        public override bool Match(string code, int index)
        {
            return Regex.IsMatch(code.Substring(index), _regex);
        }

        public override Token GetToken(string code, int index)
        {
            var value = Regex.Match(code.Substring(index), _regex).Groups[1].Value;

            return new Token(value.Length + 2, "string", value);
        }
    }
}
