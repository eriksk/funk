using System;
using System.Collections.Generic;
using Funk.Core.Lexing.Rules;

namespace Funk.Core.Lexing
{
    public class Lexer
    {
        private readonly LexRule[] _rules;

        public Lexer()
        {
            _rules = new LexRule[]
            {
                new WhiteSpaceRule(), 
                new KeywordRule(new []{ "var", "funk", "end" }),
                new OperatorRule(new []{ @"\+{1}", @"\-{1}", @"\*{1}", @"\/{1}" }), 
                new StringRule(), 
                new NumberRule(), 
                new SingleLineCommentRule(), 
                new SingleCharRule("parenthesis_open", '('), 
                new SingleCharRule("parenthesis_closed", ')'), 
                new IdentifierRule(), 
            };
        }

        public IEnumerable<Token> Tokenize(string code)
        {
            var position = 0;

            while (position < code.Length)
            {
                var anyMatch = false;
                foreach (var lexRule in _rules)
                {
                    if (lexRule.Match(code, position))
                    {
                        var token = lexRule.GetToken(code, position);
                        yield return token;
                        position += token.Length;
                        anyMatch = true;
                        break;
                    }
                }
                if (!anyMatch)
                    throw new ArgumentException(string.Format("Error in code on position: '{0}', '{1}'", position, code.Substring(position).Truncate(10)));
            }
        }
    }
}
