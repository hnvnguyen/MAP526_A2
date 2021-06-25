using Assignment2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        Manager manager;
        public FavouritesPage(Manager m)
        {
            InitializeComponent();
            manager = m;
        }

        protected async override void OnAppearing()
        {
            favouritesListView.ItemsSource = null;
            favouritesListView.ItemsSource = await manager.dbManager.CreateTable(); ;

            base.OnAppearing();
        }

        public void Delete_Clicked(Object sender, EventArgs e)
        {
            var body = (sender as MenuItem).CommandParameter as BodiesData;
            manager.dbManager.deleteFavourite(body);
            manager.networkingManager.bodies.FirstOrDefault(b => b.id == body.id).isFavourite = body.isFavourite;
            manager.networkingManager.bodies.FirstOrDefault(b => b.id == body.id).notes = body.notes;
        }

        async void favouritesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            await Navigation.PushAsync(new UpdateFavouritePage(manager, e.SelectedItem as BodiesData));
        }
    }
}