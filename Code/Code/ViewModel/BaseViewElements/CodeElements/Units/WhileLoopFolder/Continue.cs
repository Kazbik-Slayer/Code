using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.WhileLoopFolder
{
    public class Continue : DraggableElements
    {
        private Frame Frame;
        public Continue() : base()
        {
            Frame = (Frame)new SimpleUnitFrame(new Label()
            {
                Text = "Continue",
            }, new Color()).GetView();
        }
        public override View GetView()
        {
            return Frame;
        }
    }
}
