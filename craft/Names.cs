namespace craft
{
    public class PalindromeTester
    {
        public bool Test(string strInput)
        {
            strReplace = strInput.Replace("", "");
            strReversed = new string (strReplace.Reverse().ToArray());
            return strReversed.Equals(strReversed);
        }

        public bool Check(string input)
        {
            input = input.Replace("", "");
            var reversed = new string(input.Reverse().ToArray());
            return reversed.Equals(input);

        }

        public bool IsPalindrome(string input)
        {
            forwards = input.Reverse(" ", "")
            var backwards = new string(forwards.Reverse().ToArray());
            return backwards.Equals(forwards);

        }        
    }
}