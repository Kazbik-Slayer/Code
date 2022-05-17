using App2.ViewModel.BaseViewElements;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Fields
{
    public class ConsoleField : BaseView
    {
        public Label Console;
        private readonly StackLayout ConsoleLayout;
        public ConsoleField()
        {
            ConsoleLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = new Color(0 / 255.0, 83 / 255.0, 149 / 255.0),
            };
            Compose();
        }
        protected override void Compose()
        {
            Console = new Label()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 30,
                Text = "Console\n",
                Margin = new Thickness(10, 10, 10, 10),
            };
            
            ConsoleLayout.Children.Add(new Frame() 
            {
                Content = Console,
                Margin = new Thickness(10, 10, 10, 10),
                BackgroundColor = new Color(0 / 255.0, 60 / 255.0, 107 / 255.0),
                CornerRadius = 14,
            });
        }
        public override View GetView()
        {
            return ConsoleLayout;
        }
    }
}
