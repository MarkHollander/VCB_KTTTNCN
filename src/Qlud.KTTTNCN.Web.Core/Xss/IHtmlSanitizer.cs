using Abp.Dependency;

namespace Qlud.KTTTNCN.Web.Xss
{
    public interface IHtmlSanitizer: ITransientDependency
    {
        string Sanitize(string html);
    }
}