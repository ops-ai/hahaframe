using System;
using System.Text.RegularExpressions;

namespace HahaFrame.Data
{
    public static class Utils
    {
        //create a substring stripping out at the last space 
        public static string Substring(string text, int chars)
        {
            if (text == null)
                return "";

            return text.Length <= chars ? text : Substring(text, 0, chars);
        }

        public static string Substring(string text, int startindex, int chars)
        {
            var newtext = text.Substring(startindex, chars).Trim();
            return text.Length > startindex + chars ? string.Format("{0} ...", newtext.Substring(0, newtext.LastIndexOf(" ", StringComparison.Ordinal))) : newtext;
        }

        public static string StripTags(string input)
        {
            return Regex.Replace(input, @"<[^>]*>", string.Empty);
        }

        /// <summary>
        /// shorten the input string
        /// </summary>
        public static string Shorten(string input, int maxlen, bool stripHtml = false)
        {
            if (stripHtml && input != null)
                input = StripTags(input);
            string desc = input;
            if (!string.IsNullOrEmpty(desc) && desc.Length > maxlen)
            {
                desc = desc.Substring(0, maxlen);
                try
                {
                    desc = desc.Substring(0, desc.LastIndexOf(' ')).Trim() + " ...";
                }
                catch
                {
                    desc = desc.Substring(0, desc.Length) + " ...";
                }
            }
            return desc;
        }

        public static bool AddOfferToClient(bool add = false)
        {
            int ret = 0;
            var offerReq = System.Web.HttpContext.Current.Request.Cookies["afppo"];
            if (offerReq != null)
            {
                Int32.TryParse(offerReq.Value, out ret);
                if (ret < 3 && add)
                {
                    System.Web.HttpContext.Current.Request.Cookies["afppo"].Value = (ret + 1).ToString();
                    System.Web.HttpContext.Current.Response.Cookies.Add(offerReq);
                    return true;
                }
                else if (ret < 3 && !add)
                    return true;
                else
                    return false;
            }
            else
            {
                if (add)
                {
                    offerReq = new System.Web.HttpCookie("afppo") { Value = "1", Expires = DateTime.Now.AddDays(7), Name = "afppo" };
                    System.Web.HttpContext.Current.Response.Cookies.Add(offerReq);
                }
                return true;
            }

        }

        public static string ToLink(string phrase)
        {
            string str = System.Web.HttpUtility.HtmlDecode(phrase.ToLowerInvariant());
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove all non valid chars          
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
            return str;
        }
    }
}
