using Xamarin.Forms;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder
{
    public class VariableView : DraggableElements
    {
        public VariableView(MainField mainField, StackLayout stackLayout) : base()
        {
            DragAndDropParentLayout = stackLayout;
            MainField = mainField;
            Compose();
        }
        protected override void Compose()
        {
            StackLayout variableLayout = new StackLayout()
            { 
                Orientation = StackOrientation.Horizontal,
            };

            SimpleUnitEntry Name = new SimpleUnitEntry("Name", new Color(171 / 255.0, 0 / 255.0, 34 / 255.0));
            SimpleUnitEntry Value = new SimpleUnitEntry("Value", new Color(171 / 255.0, 0 / 255.0, 34 / 255.0));

            variableLayout.Children.Add(new VariableTypePicker(new Color(171 / 255.0, 0 / 255.0, 34 / 255.0)).GetView());
            variableLayout.Children.Add(Name.GetView());
            variableLayout.Children.Add(Value.GetView());

            Frame DragAndDropFrame = (Frame) new SimpleUnitFrame(variableLayout, new Color(235 / 255.0, 0 / 255.0, 47 / 255.0)).GetView();

            DragAndDropLayout.Children.Add(DragAndDropFrame);
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
