using App2.ViewModel.BaseViewElements.CodeElements.Units;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder;
using Codeblock.Model;

namespace Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts
{
    class ELSE : LogicUnit
    {
        public ELSE(MainField mainFiled, LogicBlockView logicBlockView, CodeBlock codeBlock)
        {
            MainField = mainFiled;
            LogicBlockView = logicBlockView;
            BlockView = new BlockView();
            CodeBlock = codeBlock;
            Compose();
        }
        protected override void Compose()
        {
            Frame ExpPart = (Frame)new SimpleUnitFrame(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Margin = 0,
                Padding = 0,
                Children =
                {
                    new SimpleUnitLabel("ELSE").GetView(),
                }
            }, new Color(19 / 256.0, 232 / 256.0, 143 / 256.0)).GetView();

            BlockView.BlockElementsHolder.Children.Add(ExpPart);
            BlockView.BlockElementsHolder.Children.Add(new SupplementButton(false, MainField, LogicBlockView, BlockView.BlockElementsHolder, CodeBlock).GetView());

            AssembleFrame = new Frame()
            {
                Content = BlockView.BlockElementsHolder,
                BackgroundColor = new Color(38 / 256.0, 1 / 256.0, 117 / 256.0),
                Padding = 0,
                Margin = 0,
                CornerRadius = 10,
            };
            DragAndDropLayout = new StackLayout() { Children = { AssembleFrame } };
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}