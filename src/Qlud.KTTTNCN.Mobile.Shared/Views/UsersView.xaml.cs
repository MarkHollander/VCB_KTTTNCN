﻿using Qlud.KTTTNCN.Models.Users;
using Qlud.KTTTNCN.ViewModels;
using Xamarin.Forms;

namespace Qlud.KTTTNCN.Views
{
    public partial class UsersView : ContentPage, IXamarinView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((UsersViewModel) BindingContext).LoadMoreUserIfNeedsAsync(e.Item as UserListModel);
        }
    }
}