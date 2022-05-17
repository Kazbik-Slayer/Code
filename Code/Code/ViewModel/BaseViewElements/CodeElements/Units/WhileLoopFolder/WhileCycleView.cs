using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class WhileCycleView : DraggableElements
    {
        public StackLayout WhileBlockLayout;
        public BlockView BlockView;
        public WhileCycleView(MainField mainField) : base()
        {
            MainField = mainField;
            WhileBlockLayout = new StackLayout() { Orientation = StackOrientation.Vertical };
            BlockView = new BlockView();
            Compose();
        }
        protected override void Compose()
        {
            WhileBlock whileBlock = new WhileBlock(MainField);
            BlockView = whileBlock.BlockView;
            WhileBlockLayout.Children.Add(BlockView.GetView());
            Frame frame = new Frame()
            {
                Content = WhileBlockLayout,
                Margin = 0,
                Padding = 0,
                CornerRadius = 10,
                BackgroundColor = new Color(38 / 256.0, 1 / 256.0, 117 / 256.0),
                BorderColor = new Color(255 / 256.0, 0 / 256.0, 102 / 256.0),
            };
            DragAndDropLayout.Children.Add(frame);
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
