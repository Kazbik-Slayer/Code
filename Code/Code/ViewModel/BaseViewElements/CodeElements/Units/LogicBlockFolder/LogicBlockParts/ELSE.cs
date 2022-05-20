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
        public LogicBlock LogicBlock;
        public LogicObject LogicObject;
        public ELSE(MainField mainFiled, LogicBlockView logicBlockView)
        {
            MainField = mainFiled;
            LogicBlockView = logicBlockView;
            LogicBlock = logicBlockView.LogicBlock;
            BlockView = new BlockView();
            Compose();
        }
        protected override void Compose()
        {
            LogicObject = new LogicObject(MainField, LogicBlock.CodeBlock);
            LogicObject.Input = "true";
            LogicBlock.AreaLogicObjects.Add(LogicObject);
            CodeBlock = LogicObject.Commands;

            StackLayout IfLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };

            SimpleUnitLabel label = new SimpleUnitLabel("ELSE");

            IfLayout.Children.Add(label.GetView());

            Frame ExpPart = (Frame)new SimpleUnitFrame(IfLayout, new Color(19 / 256.0, 232 / 256.0, 143 / 256.0)).GetView();

            BlockView.BlockElementsHolder.Children.Add(ExpPart);
            BlockView.BlockElementsHolder.Children.Add(new SupplementButton(false, false, MainField, LogicBlockView, BlockView.BlockElementsHolder, LogicObject.Commands).GetView());

            AssembleFrame = new Frame()
            {
                Content = BlockView.BlockElementsHolder,
                BackgroundColor = new Color(38 / 256.0, 1 / 256.0, 117 / 256.0),
                Padding = 0,
                Margin = 0,
                CornerRadius = 10,
            };

            DragAndDropLayout = new StackLayout() { Children = { AssembleFrame } };

            /*
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
            */
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}