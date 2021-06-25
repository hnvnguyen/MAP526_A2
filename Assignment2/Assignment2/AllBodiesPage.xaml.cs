using Assignment2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllBodiesPage : ContentPage
    {
        Manager manager;
        public ObservableCollection<BodiesData> allBodies;

        public AllBodiesPage(Manager m)
        {
            InitializeComponent();
            manager = m;
        }

        protected async override void OnAppearing()
        {
            allBodiesListView.ItemsSource = null;
            manager.dbManager.favourites = await manager.dbManager.CreateTable();
            manager.networkingManager.bodies = await manager.networkingManager.GetAllBodies();
            foreach (var f in manager.dbManager.favourites)
            {
                var tempB = manager.networkingManager.bodies.SingleOrDefault(b => b.id == f.id);
                if (tempB != null)
                {
                    tempB.isFavourite = true;
                    tempB.notes = f.notes;
                
                }
            }
            allBodies = new ObservableCollection<BodiesData>(manager.networkingManager.bodies);
            allBodiesListView.ItemsSource = allBodies;

            base.OnAppearing();
        }

        async void allBodiesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new BodyPage(manager, e.SelectedItem as BodiesData));
        }
    }
}