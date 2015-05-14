namespace Funk.Core.Lexing.Rules
{
    public class SingleCharRule : LexRule
    {
        private readonly string _command;
        private readonly char _character;

        public SingleCharRule(string command, char character)
        {
            _command = command;
            _character = character;
        }

        public override bool Match(string code, int index)
        {
            return code[index] == _character;
        }

        public override Token GetToken(string code, int index)
        {
            return new Token(1, _command, code[index].ToString());
        }
    }
}
