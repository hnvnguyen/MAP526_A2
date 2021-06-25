using Assignment2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment2
{
    public partial class MainPage : ContentPage
    {
        Manager manager;
        public MainPage(Manager m)
        {
            InitializeComponent();
            manager = m;           
        }

            async void AllBodiesPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllBodiesPage(manager));
        }

        async void PictureOfDayPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PictureOfDayPage(manager));
        }

        async void FavouritesPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavouritesPage(manager));
        }
    }
}
