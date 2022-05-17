using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class ArrayView : DraggableElements
    {
        public ArrayView(MainField mainField, StackLayout stackLayout) : base()
        {
            DragAndDropParentLayout = stackLayout;
            MainField = mainField;
            Compose();
        }
        protected override void Compose()
        {
            VariableTypePicker VTP = new VariableTypePicker(new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));
            SimpleUnitEntry Name = new SimpleUnitEntry("Name", new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));
            SimpleUnitEntry Length = new SimpleUnitEntry("Length", new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));

            StackLayout SetterLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    VTP.GetView(),
                    Name.GetView(),
                    Length.GetView(),
                }
            };
            
            SimpleUnitEntry Values = new SimpleUnitEntry("Enter Array Elements", new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));
            View ArrayFrame = new SimpleUnitFrame(
                new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                        SetterLayout,
                        Values.GetView(),
                    }
                }, new Color(255 / 256.0, 0 / 256.0, 81 / 256.0)
            ).GetView();
            DragAndDropLayout.Children.Add(ArrayFrame);
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
