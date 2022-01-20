using System.ComponentModel;
using Xamarin.Forms;
using apiApp.ViewModels;

namespace apiApp.Views
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
