using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Utils
{
    public class RandomOperations
    {
        #region вернуть строку из 50 случайных циферок
        public string getConfirmationCode()
        {
            string guid = "";
            Random rn = new Random();

            for (int i = 0; i < 50; i++)
            {
                guid = guid + rn.Next(0, 9);
            }
            return guid;

        }
        #endregion

        public string GetSubstring(string someString, int length)
        {
            return someString.Substring(0, length);
        }

    }
}