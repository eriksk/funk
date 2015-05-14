using System;
using System.Text.RegularExpressions;

namespace Funk.Core.Lexing.Rules
{
    public class KeywordRule : LexRule
    {
        private readonly string _regex;

        public KeywordRule(string[] keywords)
        {
            if (keywords == null) throw new ArgumentNullException("keywords");

           _regex = string.Format(@"\A({0})(\s|$)", string.Join("|", keywords));
        }

        public override bool Match(string code, int index)
        {
            return Regex.IsMatch(code.Substring(index), _regex);
        }

        public override Token GetToken(string code, int index)
        {
            var value = Regex.Match(code.Substring(index), _regex).Groups[1].Value;
            return new Token(value.Length, "keyword", value);
        }
    }
}
