using BlogStore.Domain.Utils.Pinyin;
using System.Text.RegularExpressions;
using System.Text;

namespace BlogStore.Domain.Utils
{
    public class SlugHelper
    {
        /// <summary>
        /// Generate slug.
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string GenerateSlug(string phrase)
        {
            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private static string RemoveAccent(string txt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in txt)
            {
                if (IsChinese(c))
                {
                    sb.Append(PinYin.GetPinyin(c) + " ");
                }
                else
                {
                    sb.Append(c);
                }
            }
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(sb.ToString());
            return Encoding.ASCII.GetString(bytes);
        }

        private static bool IsChinese(char txt)
        {
            return Regex.IsMatch(txt.ToString(), @"[\u4E00-\u9FA5]+$");
        }
    }
}
