using Xamarin.Forms;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using App2.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;

namespace Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts
{
    public class IF_Block : LogicUnit
    {
        public LogicBlock LogicBlock;
        public LogicObject LogicObject;
        public IF_Block(MainField mainField, LogicBlockView logicBlockView)
        {
            BlockView = new BlockView();
            MainField = mainField;
            LogicBlockView = logicBlockView;
            LogicBlock = logicBlockView.LogicBlock;
            Compose();
        }
        protected override void Compose()
        {
            LogicObject = new LogicObject(MainField, LogicBlock.CodeBlock);
            LogicBlock.AreaLogicObjects.Add(LogicObject);
            CodeBlock = LogicObject.Commands;

            StackLayout IfLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };

            SimpleUnitLabel label = new SimpleUnitLabel("IF");
            SimpleUnitEntry entry = new SimpleUnitEntry("Expression", new Color(14 / 256.0, 150 / 256.0, 93 / 256.0));
            SupplementButton button = new SupplementButton(true, false, MainField, LogicBlockView, BlockView.BlockElementsHolder, LogicObject.Commands);

            entry.Entry.TextChanged += EntryValueChanged;

            IfLayout.Children.Add(label.GetView());
            IfLayout.Children.Add(entry.GetView());
            IfLayout.Children.Add(button.GetView());

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

            /*Frame DragAndDropFrame = (Frame)new SimpleUnitFrame(IfLayout, new Color(19 / 256.0, 232 / 256.0, 143 / 256.0)).GetView();

            DragAndDropLayout.Children.Add(DragAndDropFrame);*/
            
            /*
                        Frame ExpPart = (Frame) new SimpleUnitFrame(new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                            Margin = 0,
                            Padding = 0,
                            Children = 
                            {
                                new SimpleUnitLabel("IF").GetView(),
                                new SimpleUnitEntry("Expression", new Color(14 / 256.0, 150 / 256.0, 93 / 256.0)).GetView(),
                                new SupplementButton(true, MainField, LogicBlockView, BlockView.BlockElementsHolder, LogicObject.Commands).GetView(),
                            }
                        },new Color(19 / 256.0, 232 / 256.0, 143 / 256.0)).GetView();

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

                        DragAndDropLayout = new StackLayout(){ Children = { AssembleFrame } };\
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