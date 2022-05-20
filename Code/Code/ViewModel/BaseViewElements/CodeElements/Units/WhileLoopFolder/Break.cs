using App2.ViewModel.BaseViewElements;
using System;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.WhileLoopFolder
{
    public class Break : DraggableElements
    {
        private Frame Frame;
        public Break() : base()
        {
            Frame = (Frame)new SimpleUnitFrame(new Label()
            {
                Text = "Break",
            }, new Color()).GetView();
        }
        public override View GetView()
        {
            return Frame;
        }
    }
}
