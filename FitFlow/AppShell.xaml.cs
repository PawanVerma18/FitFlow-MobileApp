using FitFlow.ViewModels;
using FitFlow.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;



namespace FitFlow
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(MembershipPage), typeof(MembershipPage));
        }
    }
}
