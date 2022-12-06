using System.Threading.Tasks;

namespace Qlud.KTTTNCN.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}