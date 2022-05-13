using Xamarin.Forms;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;

namespace App2.ViewModel.BaseViewElements.CodeElements.BlcokViews
{
    public class MainBlockView : Block
    {
        public MainBlockView()
        {
            BlockElementsHolder = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Margin = 3,
                Padding = 0,
                Spacing = 10,
            };
        }
        public override View GetView()
        {
            return BlockElementsHolder;
        }
    }
}
