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
    public partial class BodyPage : ContentPage
    {
        Manager manager;
        BodiesData body;
        public BodyPage(Manager m, BodiesData b)
        {
            InitializeComponent();
            manager = m;
            body = b;
            stackLayout.BindingContext = body;
        }

        private void AddFavourite_Clicked(object sender, EventArgs e)
        {
            if (body.isFavourite == true) {
                DisplayAlert(body.name, body.name + " is already inside your favourites!", "Okay");
                return;
            }
            DisplayAlert(body.name, body.name + " is now inside your favourites!", "Okay");
            body.isFavourite = true;
            manager.dbManager.addFavourite(body);
            manager.networkingManager.bodies.FirstOrDefault(b => b.id == body.id).isFavourite = true;
        }
    }
}