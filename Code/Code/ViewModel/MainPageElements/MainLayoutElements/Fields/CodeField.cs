using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Fields
{
    public class CodeField : BaseView
    {
        private readonly StackLayout CodeFieldLayout;
        private readonly ScrollView ScrollView;
        public MainBlockView MainBlockView;
        public CodeField()
        {
            CodeFieldLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = new Color(0 / 255.0, 83 / 255.0, 149 / 255.0),
                Spacing = 0,
                Padding = 0,
                Margin = 0,
            };
            ScrollView = new ScrollView()
            {
                Content = CodeFieldLayout,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            Compose();
        }
        protected override void Compose()
        {
            MainBlockView = new MainBlockView();
            CodeFieldLayout.Children.Add(MainBlockView.GetView());
        }
        public override View GetView()
        {
            return ScrollView;
        }
    }
}
