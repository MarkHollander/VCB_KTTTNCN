using System.Text.RegularExpressions;

namespace Qlud.KTTTNCN.Web.Xss
{
    
    public class DefaultHtmlSanitizer : IHtmlSanitizer
    {
        public string Sanitize(string html)
        {
            return Regex.Replace(html, "<.*?>|&.*?;", string.Empty);
        }
    }
}