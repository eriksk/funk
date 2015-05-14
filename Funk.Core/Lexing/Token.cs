namespace Funk.Core.Lexing
{
    public class Token
    {
        public int Length;
        public string Command;
        public string Value;

        public Token(int length, string command, string value)
        {
            Length = length;
            Command = command;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}({2})", Command, Value, Length);
        }
    }
}