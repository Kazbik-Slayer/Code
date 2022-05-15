using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.BlockViews
{
    public class BlockView : Block
    {
        public BlockView() : base()
        {
        }
        public override View GetView()
        {
            return BlockElementsHolder;
        }
    }
}
