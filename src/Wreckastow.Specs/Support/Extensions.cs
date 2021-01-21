using System.Web;

namespace WreckaStow.Specs.Support
{
    internal static class Extensions
    {
        internal static string HtmlDecode(this string s)
        {
            return null == s ? s : HttpUtility.HtmlDecode(s);
        }
    }
}
