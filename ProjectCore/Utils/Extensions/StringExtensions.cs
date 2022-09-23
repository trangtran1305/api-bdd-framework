using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCore.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string CapSentences(this string str)
        {
            string s = "";

            if (str[str.Length - 1] == '.')
                str = str.Remove(str.Length - 1, 1);

            char[] delim = { ' ' };

            string[] tokens = str.Split(delim);

            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].Trim();

                tokens[i] = char.ToUpper(tokens[i][0]) + tokens[i].Substring(1);

                s += tokens[i] + "";
            }

            return s;
        }
    }
}
