namespace craft
{
    public class PalindromeTester
    {
        public bool Test(string strInput)
        {
            string strTrimmed = strInput.Replace("", "");
            string strReversed = new string (strTrimmed.Reverse().ToArray());
            return strReversed.Equals(strReversed);
        }

        public bool Check(string input){}

        public bool IsPalindrome(string input){}        
    }
}