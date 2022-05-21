using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Xamarin.Forms;

namespace Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts
{
    public class LogicUnit : DraggableElements
    {
        public LogicUnit() : base()
        {

        }
        public BlockView BlockView;
        protected Frame AssembleFrame;
        protected LogicBlockView LogicBlockView;
    }
}
