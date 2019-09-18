using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PralnaDemo.Utils
{
    public class StringOperations
    {

        // when test question or answer has formatted programming code
        public static string convertToHTML(string someString)
        {
			if(string.IsNullOrEmpty(someString))
			{
				return "";
			}

            // Replace(" ", "&nbsp;").
            string result = someString.Replace("\r\n", "\n").Replace("\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace("&lt;", "<").Replace("&quot;", "\"").Replace("&gt;", ">");

            result = formatHrefLinks(result);

            return result;
        }


        #region форматирование ссылок

        public static string formatHrefLinks(string description)
        {
            description = description.Replace("'", "`");

            string result = "";
			if(string.IsNullOrEmpty(description))
			{
				return result;
			}
			bool isHttps = false;
			
            while (description.Length > 0 && (description.IndexOf("http://") > -1 || description.IndexOf("https://") > -1))
            {
                isHttps = false;

				if (description.IndexOf("http://") > -1 && description.IndexOf("https://") > -1 && description.IndexOf("https://") < description.IndexOf("http://"))
                {
                    isHttps = true;
                }
                else if(description.IndexOf("http://") == -1 && description.IndexOf("https://") > -1)
				{
                    isHttps = true;
				}

				string httpString = "http://";
				
                if (isHttps)
				{
					httpString = "https://";
				}
                              
                // получили левую часть до начала ссылки
				string leftHalf = description.Substring(0, description.IndexOf(httpString)); // получили текст до ссылки 

                // обрезали эту часть из оставшегося текста
                description = description.Substring(leftHalf.Length); // обрезали левую часть до начала ссылки (потеряли)

                //нашли линк
                string link = getLink(description, isHttps); // нашли и вычленили ссылку

                // получили текст после линка
                description = description.Substring(link.Length); // обрезали текст так, что имеем только текст после ссылки

                link = link.Replace("&amp;", "&");

                result = result + leftHalf + "<a class=\"underlined\" onclick=\"return !window.open(this.href)\" title=\"(откроется в новом окне)\" href=\"" + link + "\">" + link + "</a>";


                //   result = result + leftHalf + "<a title=\"(откроется в новом окне)\" target=\"_blank\" href=\"" + link + "\">" + link + "</a>";

            }

            result += description;

            return result;

        }

        private static string getLink(string someString, bool isHttps)
        {
			string httpString = "http://";
			if (isHttps)
			{
				httpString = "https://";
			}

			string result = someString.Substring(0, (httpString).Length); //http://

            someString = someString.Substring(result.Length);

            try
            {

                while ((someString.Length == 1 &&
                    someString.Substring(0, 1) != "(" &&
                    someString.Substring(0, 1) != ")" &&
                       someString.Substring(0, 1) != "," &&
                       someString.Substring(0, 1) != "!" &&
                       someString.Substring(0, 1) != "?" &&
                       someString.Substring(0, 1) != ">" &&
                       someString.Substring(0, 1) != "<" &&
                       someString.Substring(0, 1) != "\n" &&
                       someString.Substring(0, 1) != "\r" &&
                       someString.Substring(0, 1) != ";" &&
                       someString.Substring(0, 1) != ":" &&
                       someString.Substring(0, 1) != " ") ||
                    (someString.Length > 1 &&
                    someString.Substring(0, 2) != ". " &&
                       someString.Substring(0, 1) != ")" &&
                       someString.Substring(0, 2) != ", " &&
                       someString.Substring(0, 2) != "! " &&
                       someString.Substring(0, 2) != "? " &&
                       someString.Substring(0, 1) != ">" &&
                       someString.Substring(0, 1) != "<" &&
                       someString.Substring(0, 1) != "\n" &&
                       someString.Substring(0, 1) != "\r" &&
                       someString.Substring(0, 2) != ": " &&
                       someString.Substring(0, 2) != "; " &&
                       someString.Substring(0, 2) != ";\r" &&
                       someString.Substring(0, 2) != ";\n" &&
                       someString.Substring(0, 2) != ";<" &&
                       someString.Substring(0, 2) != ": " &&
                       someString.Substring(0, 2) != ":\r" &&
                       someString.Substring(0, 2) != ":\n" &&
                       someString.Substring(0, 2) != ":<" &&
                       someString.Substring(0, 1) != " "))
                {
                    result += someString.Substring(0, 1); // получили первую букву
                    someString = someString.Substring(1); // обрезали левую букву
                }
            }
            catch (Exception ex)
            {

            }

            return result;

        }


        #endregion


        // when test question or answer has formatted programming code
        public static string convertToHTML(string someString, bool withTrim, bool saveSpace)
        {
            if (withTrim == true)
            {
                someString = someString.Trim();
            }

            string result = someString.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");

            if (saveSpace)
            {
                result = result.Replace(" ", "&nbsp;");
                result = result.Replace(".&nbsp;", ". ").Replace(",&nbsp;", ", ").Replace("\"&nbsp;", "\" ").Replace(":&nbsp;", ": ").Replace(";&nbsp;", "; ").Replace("!&nbsp;", "! ").Replace("?&nbsp;", "? ");
            }


            return result;
        }

        public static string GetPercent(int totalQuantity, int someQuantity)
        {
            if(someQuantity == 0 || totalQuantity / someQuantity == 0)
            {
                return "0";
            }

            double result = (double)100 / ((double)totalQuantity / (double)someQuantity) ;
            string resultAsString = result.ToString("0.##");
            return resultAsString;
        }

        // server can not save file with national symbols, so name should be fixed firstly
        public static string removeNonEnglishLettersFromFileName(string someString)
        {
			someString = makeFileNameUnique(someString);

            string extension = Path.GetExtension(someString);
            string filePath = Path.GetDirectoryName(someString);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(someString);

            fileNameWithoutExtension = fileNameWithoutExtension.Replace(' ', '_');

            bool hasNonUnicode = false;
            string result = "";
            foreach (char ch in fileNameWithoutExtension)
            {
                if ((int)ch >= 128)
                {
                    hasNonUnicode = true;
                }
                else
                {
                    result = result + ch;
                }
            }

            if (result.Length == 0 || hasNonUnicode)
            {

                if (hasNonUnicode)
                {
                    result = result + "_";
                }

                result += DateTime.Now.ToLongTimeString();
                result = result.Replace(".", "").Replace(",", "").Replace(" ", "_").Replace(":", "");
            }

            string fixedFileName = "";

            if (filePath.Length > 0)
            {
                fixedFileName = filePath + "\\";
            }

            fixedFileName = fixedFileName + HttpUtility.UrlEncode(result).Replace("%", "") + extension;

            fixedFileName = fixedFileName.Trim('_').Trim('-');

            //fixedFileName = makeFileNameUnique(fixedFileName);

            return fixedFileName;

        }

        public static string makeFileNameUnique(string someFileName)
        {
            string result = someFileName;

            while (System.IO.File.Exists(someFileName))
            {
                string extension = Path.GetExtension(someFileName);
                string filePath = Path.GetDirectoryName(someFileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(someFileName);

                string NewFileName = fileNameWithoutExtension + "_" +
                            DateTime.Now.ToString().Replace(':',
                            '-').Replace(' ', '-').Replace('/', '.') + "." + DateTime.Now.Millisecond.ToString("0000");

                result = filePath + "\\" + NewFileName + extension;
                someFileName = result;
            }

            return result;
        }

        // not in use
        public static string addDatetimeToFileName(string someFile)
        {
            string result = Path.GetFileNameWithoutExtension(someFile) + DateTime.Now + Path.GetExtension(someFile);

            return removeNonEnglishLettersFromFileName(result);
        }

        // converts path to local path
        public static string convertToLocalPath(string somePath)
        {
            somePath = somePath.Replace("/", "\\");
            somePath = somePath.Replace("\\\\", "\\");
            return somePath;
        }

        // caonverts path to url
        public static string convertToUrl(string somePath)
        {
            somePath = convertToLocalPath(somePath).Replace("\\", "/");
            return somePath;
        }

        public static int getLinesCount(string someString)
        {
            someString = someString.ToLower().Replace("<p>", "\n").Replace("<br>", "\n").Replace("<br />", "\n").Trim();

            string[] array = someString.Split('\n');

            return array.Length;
        }

        public static string GetDomainFromUrl(string url)
        {
            url = url.Replace("www.", "").Replace("http://", "");

            if (url.IndexOf(':') > -1)
            {
                url = url.Substring(0, url.IndexOf(':'));
            }

            if (url.IndexOf('/') > -1)
            {
                url = url.Substring(0, url.IndexOf('/'));
            }

           

            return url;
        }

        public static Int64 GetRandomInt64()
        {
            string tempResult = (DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + DateTime.Now.Millisecond).ToString().Replace(":", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Replace(",", string.Empty).Replace("PM", "").Replace("AM", "").Replace("/", "");

            Int64 result = Convert.ToInt64(tempResult);
            return result;
        }
    }
}