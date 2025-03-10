using FitFlow.Models;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class UserDetailsPage : ContentPage
    {
        public UserDetailsPage(User user)
        {
            InitializeComponent();
            nameLabel.Text = user.Name;
            emailLabel.Text = user.Email;
        }
    }
}
