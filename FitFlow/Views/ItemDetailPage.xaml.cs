using FitFlow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FitFlow.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}