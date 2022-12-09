using Qlud.KTTTNCN.Models.Tenants;
using Qlud.KTTTNCN.ViewModels;
using Xamarin.Forms;

namespace Qlud.KTTTNCN.Views
{
    public partial class TenantsView : ContentPage, IXamarinView
    {
        public TenantsView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((TenantsViewModel)BindingContext).LoadMoreTenantsIfNeedsAsync(e.Item as TenantListModel);
        }
    }
}