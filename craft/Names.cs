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

        public bool Check(string input){}

        public bool IsPalindrome(string input){}        
    }
}