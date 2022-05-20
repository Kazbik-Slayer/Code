using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.ConverterFolder
{
    public class ConverterView : DraggableElements
    {
        public ConverterView() : base()
        {
            Compose();
        }
        protected override void Compose()
        {
            SimpleUnitEntry name = new SimpleUnitEntry("Name", new Color(179 / 256.0, 0 / 256.0, 101 / 256.0));
            VariableTypePicker newType = new VariableTypePicker(new Color(179 / 256.0, 0 / 256.0, 101 / 256.0));

            Frame SUF = (Frame) new SimpleUnitFrame(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Margin = 0,
                Padding = 0,
                Children =
                {
                    name.GetView(),
                    newType.GetView(),
                }
            }, new Color(224 / 256.0, 0 / 256.0, 127 / 256.0)).GetView();

            DragAndDropLayout.Children.Add(SUF);
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
