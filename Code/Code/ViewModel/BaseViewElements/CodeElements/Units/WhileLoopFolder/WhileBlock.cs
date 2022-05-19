using App2.ViewModel.BaseViewElements.CodeElements.Units;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder;
using Codeblock.Model;

namespace Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts
{
    class WhileBlock : LogicUnit
    {
        public LogicObject LogicObject;
        public WhileBlock(MainField mainFiled, LogicObject logicObject)
        {
            MainField = mainFiled;
            LogicObject = logicObject;
            CodeBlock = logicObject.Commands;
            BlockView = new BlockView();
            Compose();
        }
        protected override void Compose()
        {
            StackLayout WhileLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };

            SimpleUnitEntry entry = new SimpleUnitEntry("Expression", new Color(194 / 256.0, 0 / 256.0, 78 / 256.0));

            entry.Entry.TextChanged += EntryValueChanged;

            WhileLayout.Children.Add(entry.GetView());

            Frame ExpPart = (Frame)new SimpleUnitFrame(WhileLayout, new Color(255 / 256.0, 0 / 256.0, 102 / 256.0)).GetView();

            BlockView.BlockElementsHolder.Children.Add(ExpPart);
            BlockView.BlockElementsHolder.Children.Add(new SupplementButton(false, MainField, LogicBlockView, BlockView.BlockElementsHolder, LogicObject.Commands).GetView());

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
                                new SimpleUnitLabel("WHILE").GetView(),
                                new SimpleUnitEntry("Expression", new Color(194 / 256.0, 0 / 256.0, 78 / 256.0)).GetView(),
                            }
                        }, new Color(255 / 256.0, 0 / 256.0, 102 / 256.0)).GetView();

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
        public void EntryValueChanged(object sender, TextChangedEventArgs e)
        {
            LogicObject.Input = e.NewTextValue;
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
