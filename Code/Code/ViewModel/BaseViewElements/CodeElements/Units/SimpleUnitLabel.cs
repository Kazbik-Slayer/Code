using App2.ViewModel.BaseViewElements;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class SimpleUnitLabel : BaseView
    {
        private readonly Label Label;
        public SimpleUnitLabel(string text)
        {
            Label = new Label()
            {
                Text = text,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 18,
                Margin = 3,
            };
        }
        public override View GetView()
        {
            return Label;
        }
    }
}
