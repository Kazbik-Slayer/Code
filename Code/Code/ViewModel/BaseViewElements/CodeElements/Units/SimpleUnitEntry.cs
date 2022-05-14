using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class SimpleUnitEntry : BaseView
    {
        private readonly Frame Frame;
        public SimpleUnitEntry(string placeHoler, Color color)
        {
            Entry Entry = new Entry()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Placeholder = placeHoler,
                BackgroundColor = color,
                TextColor = Color.Black,
            };
            Frame = new Frame()
            {
                Content = Entry,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = color,
                CornerRadius = 10,
                Margin = 0,
                Padding = 0,
            };
        }
        public override View GetView()
        {
            return Frame;
        }
    }
}
