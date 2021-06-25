using Assignment2.Model;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment2
{
    public partial class App : Application
    {
        Manager manager;
        public App()
        {
            InitializeComponent();
            manager = new Manager();
            MainPage = new NavigationPage(new MainPage(manager));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
