using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Fields;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents
{
    public class MainLayout : BaseView
    {
        private StackLayout MainStackLayout;
        public MainLayout()
        {
            MainStackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                Margin = 0,
                Padding = 0,
            };
            Compose();
        }
        protected override void Compose()
        {
            Header header = new Header();
            MainField mainField = new MainField();
            Footer footer = new Footer(mainField);

            MainStackLayout.Children.Add(header.GetView());
            MainStackLayout.Children.Add(mainField.GetView());
            MainStackLayout.Children.Add(footer.GetView());
        }
        public override View GetView()
        {
            return MainStackLayout;
        }
    }
}
