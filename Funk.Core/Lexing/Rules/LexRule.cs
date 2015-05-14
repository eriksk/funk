namespace Funk.Core.Lexing.Rules
{
    public abstract class LexRule
    {
        public abstract bool Match(string code, int index);
        public abstract Token GetToken(string code, int index);
    }
}