using System.Text.RegularExpressions;

namespace Funk.Core.Lexing.Rules
{
    public class SingleLineCommentRule : LexRule
    {
        private readonly string _regex;

        public SingleLineCommentRule()
        {
            _regex = @"\A#(.*)$";
        }

        public override bool Match(string code, int index)
        {
            return Regex.IsMatch(code.Substring(index), _regex);
        }

        public override Token GetToken(string code, int index)
        {
            var value = Regex.Match(code.Substring(index), _regex).Groups[1].Value;

            return new Token(value.Length + 1, "single_line_comment", value);
        }
    }
}
