using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Fields;
using Code.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements
{
    public class Footer : BaseView
    {
        private readonly StackLayout FooterStackLayout;
        private readonly MainField MainField;
        public Footer(MainField mainField)
        {
            MainField = mainField;
            FooterStackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = new Color(1 / 255.0, 44 / 255.0, 75 / 255.0),
                FlowDirection = FlowDirection.LeftToRight,
                Spacing = 0,
                Padding = 0,
                Margin = 0,
            };
            Compose();
        }
        protected override void Compose()
        {
            FooterStackLayout.Children.Add(new LaunchButton().GetView());
            FooterStackLayout.Children.Add(new ConsoleButton(MainField).GetView());
            FooterStackLayout.Children.Add(new CodeButton(MainField).GetView());
            FooterStackLayout.Children.Add(new AdditionButton(MainField).GetView());
        }
        public override View GetView()
        {
            return FooterStackLayout;
        }
    }
}
