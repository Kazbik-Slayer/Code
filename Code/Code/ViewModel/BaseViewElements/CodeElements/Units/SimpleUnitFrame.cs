using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class SimpleUnitFrame : BaseView
    {
        private readonly Frame Frame;
        public SimpleUnitFrame(View content, Color color)
        {
            Frame = new Frame()
            {
                Content = content,
                BackgroundColor = color,
                CornerRadius = 10,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = 10,
                Margin = 0,
            };
        }
        public override View GetView()
        {
            return Frame;
        }
    }
}
