using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.BlockViews
{
    public class MainBlockView : Block
    {
        public MainBlockView() : base()
        {

        }
        public override View GetView()
        {
            return BlockElementsHolder;
        }
    }
}
