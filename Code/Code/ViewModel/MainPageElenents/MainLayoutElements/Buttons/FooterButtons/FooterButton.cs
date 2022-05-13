using App2.ViewModel.BaseViewElements;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    public class FooterButton : BaseView
    {
        private Button Button;
        public FooterButton(string buttonName)
        {
            Button = new Button
            {
                Text = buttonName,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = new Color(188 / 255.0, 23 / 255.0, 92 / 255.0),
                CornerRadius = 10,
                Margin = 5,
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
