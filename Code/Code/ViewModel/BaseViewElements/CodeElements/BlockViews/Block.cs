using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.BlockViews
{
    public class Block : DraggableElements
    {
        public StackLayout BlockElementsHolder;
        public Block()
        {
            BlockElementsHolder = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Margin = 0,
                Padding = 0,
                Spacing = 0,
            };
        }
    }
}
