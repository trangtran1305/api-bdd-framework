using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANCarClassic.Pages
{
    //Should put all common handle in pages here
    public class PageHelper
    {
        public Tuple<string, string,string> SplitDate(string date)
        {
            var splittedDate = date.Split('/');
            var day = splittedDate[0];
            var month = splittedDate[1];
            var year = splittedDate[2];
            return new Tuple<string, string, string> (day, month, year);
        }

        public List<string> SplitBy(string input, string splitIcon)
        {
            var lstString = input.Split(splitIcon).ToList();
            return lstString;
        }
    }
}
