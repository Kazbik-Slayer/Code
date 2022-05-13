using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder
{
    public class VariableView : DraggableElements
    {
        public VariableView()
        {
            DragAndDropLayout = new StackLayout();
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

            Frame frame = (Frame) new SimpleUnitFrame(variableLayout, new Color(235 / 255.0, 0 / 255.0, 47 / 255.0)).GetView();

            DragAndDropLayout.Children.Add(frame);
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
