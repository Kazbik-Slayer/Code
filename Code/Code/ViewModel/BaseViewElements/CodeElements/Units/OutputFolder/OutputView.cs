using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class OutputView : DraggableElements
    {
        public OutputBlock OutputBlock;
        private Frame Frame;
        public OutputView(MainField mainField, StackLayout stackLayout, CodeBlock codeBlock) : base()
        {
            OutputBlock = new OutputBlock(mainField);
            codeBlock.AddOutputBlock(OutputBlock);

            SimpleUnitEntry SUE = new SimpleUnitEntry("Write What You Wanna See", new Color(148 / 256.0, 28 / 256.0, 90 / 256.0));
            SUE.Entry.TextChanged += EntryValueChanged;
            SimpleUnitFrame SUF= new SimpleUnitFrame(SUE.GetView(), new Color(189 / 256.0, 40 / 256.0, 117 / 256.0));
            Frame = (Frame) SUF.GetView();
            DragAndDropLayout.Children.Add(Frame);
        }
        public void EntryValueChanged(object sender, TextChangedEventArgs e)
        {
            OutputBlock.Input = e.NewTextValue;
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
