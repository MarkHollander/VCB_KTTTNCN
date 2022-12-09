using System.Threading.Tasks;
using Qlud.KTTTNCN.Views;
using Xamarin.Forms;

namespace Qlud.KTTTNCN.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
