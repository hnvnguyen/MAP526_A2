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
    public partial class PictureOfDayPage : ContentPage
    {
        Manager manager;
        public PictureOfDayData pic;
        public PictureOfDayPage(Manager m)
        {
            InitializeComponent();
            manager = m;
        }

        protected async override void OnAppearing() {
            pic = await manager.networkingManager.GetPictureOfDay();
            body.BindingContext = pic;

            base.OnAppearing();
        }
    }
}