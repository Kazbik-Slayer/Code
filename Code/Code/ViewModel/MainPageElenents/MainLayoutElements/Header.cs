using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.HeaderElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements
{
    public class Header : BaseView
    {
        StackLayout HeaderLayout;
        public Header()
        {
            HeaderLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = new Color(1 / 255.0, 44 / 255.0, 75 / 255.0),
                Spacing = 0,
                Margin = 0,
                Padding = 0,
            };
            Compose();
        }
        protected override void Compose()
        {
            HeaderLayout.Children.Add(new NameLabel("Visual Code").GetView());
        }
        public override View GetView()
        {
            return HeaderLayout;
        }
    }
}
