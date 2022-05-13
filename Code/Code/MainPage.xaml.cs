using App2.ViewModel.MainPageElenents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Code
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MainLayout mainLayout = new MainLayout();
            Content = mainLayout.GetView();
        }
    }
}