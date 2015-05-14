using System;
using System.Text.RegularExpressions;

namespace Funk.Core.Lexing.Rules
{
    public class NumberRule : LexRule
    {
        private bool IsValidNumber(string number)
        {
            if (number == "")
                return false;

            return Regex.IsMatch(number, @"([0-9]*\.[0-9]*|[0-9]*)");
        }

        public override bool Match(string code, int index)
        {
            return IsValidNumber(GetNumberString(code, index));
        }

        private string GetNumberString(string code, int index)
        {
            var segmentLength = code.Substring(index).Length;
            var i = index;
            var value = "";
            while (i < segmentLength && (char.IsDigit(code[i]) || code[i] == '.'))
            {
                value += code[i++];
            }
            return value;
        }

        public override Token GetToken(string code, int index)
        {
            var value = GetNumberString(code, index);

            return new Token(value.Length, "number", value);
        }
    }
}
