using FitFlow.Services;
using FitFlow.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FitFlow
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Register your data store or other services
            DependencyService.Register<MockDataStore>();


            // Set the MainPage to be the AppShell
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes


            InitializeComponent();

            // Set the main page of the app
            MainPage = new NavigationPage(new MembershipPage());
        }
        

    }
}

