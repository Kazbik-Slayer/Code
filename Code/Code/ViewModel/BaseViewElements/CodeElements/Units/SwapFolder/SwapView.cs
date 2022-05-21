using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;
using System;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.ConverterFolder
{
    public class SwapView : DraggableElements
    {
        public SwapBlock SwapBlock;
        public SwapView(MainField mainField, StackLayout stackLayout, CodeBlock codeBlock) : base()
        {
            MainField = mainField;
            DragAndDropParentLayout = stackLayout;
            CodeBlock = codeBlock;
            Compose();
        }
        protected override void Compose()
        {
            SwapBlock = new SwapBlock(MainField);
            CodeBlock.AddSwapBlock(SwapBlock);

            Node = SwapBlock;

            SimpleUnitEntry nameFirst = new SimpleUnitEntry("Name", new Color(179 / 256.0, 0 / 256.0, 53 / 256.0));
            SimpleUnitEntry nameSecond  = new SimpleUnitEntry("Name", new Color(179 / 256.0, 0 / 256.0, 53 / 256.0));

            nameFirst.Entry.TextChanged += EntryNameFirstChanged;
            nameSecond.Entry.TextChanged += EntryNameSecondChanged;

            Frame SUF = (Frame)new SimpleUnitFrame(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Margin = 0,
                Padding = 0,
                Children =
                {
                    nameFirst.GetView(),
                    nameSecond.GetView(),
                }
            }, new Color(255 / 256.0, 0 / 256.0, 76 / 256.0)).GetView();

            DragAndDropLayout.Children.Add(SUF);
        }
        public void EntryNameFirstChanged(object sender, TextChangedEventArgs e)
        {
            SwapBlock.InputFirst = e.NewTextValue;
        }
        public void EntryNameSecondChanged(object sender, TextChangedEventArgs e)
        {
            SwapBlock.InputSecond = e.NewTextValue;
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
