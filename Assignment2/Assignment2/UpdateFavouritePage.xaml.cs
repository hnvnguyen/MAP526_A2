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
    public partial class UpdateFavouritePage : ContentPage
    {
        Manager manager;
        BodiesData body;
        public UpdateFavouritePage(Manager m, BodiesData b)
        {
            InitializeComponent();
            manager = m;
            body = b;
            stackLayout.BindingContext = body;
        }

        private void UpdateFavourite_Clicked(object sender, EventArgs e)
        {
            body.notes = notesEditor.Text;
            DisplayAlert("Note updated for " + body.name, body.notes, "OK");
            manager.dbManager.updateFavourite(body);
            if (manager.networkingManager.bodies != null)
            {
                BodiesData bo = manager.networkingManager.bodies.FirstOrDefault(b => b.id == body.id);
                if (bo != null)
                    bo.notes = body.notes;
            }
        }
    }
}