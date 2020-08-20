using System;
using System.Collelections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace acme.common
{
    public class StringHandler
    {
        
        public string InsertSpaces(string source)
        {
            string result = string.Empty;
            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result += " ";
                    }                    
                }
                return result
            }
        }


    }
}