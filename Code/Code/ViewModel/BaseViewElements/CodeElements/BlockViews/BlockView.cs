using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.BlockViews
{
    public class BlockView : Block
    {
        public BlockView()
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
