using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class OutputView : DraggableElements
    {
        private Frame Frame;
        public OutputView()
        {
            SimpleUnitEntry SUE = new SimpleUnitEntry("Write What You Wanna See", new Color(148 / 256.0, 28 / 256.0, 90 / 256.0));
            SimpleUnitFrame SUF= new SimpleUnitFrame(SUE.GetView(), new Color(189 / 256.0, 40 / 256.0, 117 / 256.0));
            Frame = (Frame) SUF.GetView();
        }
        public override View GetView()
        {
            return Frame;
        }
    }
}
