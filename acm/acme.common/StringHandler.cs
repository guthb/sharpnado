using System;
using System.Collelections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace acme.common
{
    public static class StringHandler
    {
        
        public static string InsertSpaces(string source)
        {
            string result = string.Empty;
            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        //space removal if already there
                        result = result.Trim();
                        result += " ";
                    }                    
                }
                result = result.Trim();
                return = result
            }
        }


    }
}