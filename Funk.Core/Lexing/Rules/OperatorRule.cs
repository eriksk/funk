using System;
using System.Text.RegularExpressions;

namespace Funk.Core.Lexing.Rules
{
    public class OperatorRule: LexRule
    {
        private readonly string _regex;

        public OperatorRule(string[] operators)
        {
            if (operators == null) throw new ArgumentNullException("operators");

           _regex = string.Format(@"\A({0})", string.Join("|", operators));
        }

        public override bool Match(string code, int index)
        {
            return Regex.IsMatch(code.Substring(index), _regex);
        }

        public override Token GetToken(string code, int index)
        {
            var value = Regex.Match(code.Substring(index), _regex).Groups[1].Value;
            return new Token(value.Length, "operator", value);
        }
    }
}
