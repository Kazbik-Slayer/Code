using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.HeaderElements
{
    internal class NameLabel : BaseView
    {
        private Label Label;
        public NameLabel(string name)
        {
            Label = new Label()
            {
                Text = name,
                TextColor = new Color(240 / 255.0, 31 / 255.0, 139 / 255.0),//240, 31, 139
                Margin = 8,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HeightRequest = 35,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };
        }
        public override View GetView()
        {
            return Label;
        }
    }
}
