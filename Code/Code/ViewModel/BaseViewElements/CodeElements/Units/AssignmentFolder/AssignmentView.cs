using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class AssignmentView : DraggableElements
    {
        public Variable Variable;
        public AssignmentView(MainField mainField, StackLayout stackLayout, CodeBlock codeBlock) : base()
        {
            Variable = new Variable(mainField);
            codeBlock.AddAssignment(Variable);
            DragAndDropParentLayout = stackLayout;
            StackLayout assignmentLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };

            MainField = mainField;

            Node = Variable;

            SimpleUnitEntry Name = new SimpleUnitEntry("Name", new Color(156 / 256.0, 8 / 256.0, 60 / 256.0));
            SimpleUnitEntry Value = new SimpleUnitEntry("Value", new Color(156 / 256.0, 8 / 256.0, 60 / 256.0));

            Name.Entry.TextChanged += EntryNameChanged;
            Value.Entry.TextChanged += EntryValueChanged;

            assignmentLayout.Children.Add(Name.GetView());
            assignmentLayout.Children.Add(Value.GetView());

            Frame DragAndDropFrame = (Frame)new SimpleUnitFrame(assignmentLayout, new Color(189 / 256.0, 0 / 256.0, 66 / 256.0)).GetView();

            DragAndDropLayout.Children.Add(DragAndDropFrame);

            /*
                        Frame Frame = (Frame)new SimpleUnitFrame(new StackLayout()
                        {
                            Children =
                            {
                                new SimpleUnitEntry("Name", new Color(156 / 256.0, 8 / 256.0, 60 / 256.0)).GetView(),
                                new SimpleUnitEntry("Value", new Color(156 / 256.0, 8 / 256.0, 60 / 256.0)).GetView(),
                            },
                            Orientation = StackOrientation.Horizontal,
                            Margin = 0,
                            Spacing = 3
                        }, new Color(189 / 256.0, 0 / 256.0, 66 / 256.0)).GetView();
                        DragAndDropLayout.Children.Add(Frame);
            */
        }
        public void EntryNameChanged(object sender, TextChangedEventArgs e)
        {
            Variable.Name = e.NewTextValue;
        }
        public void EntryValueChanged(object sender, TextChangedEventArgs e)
        {
            Variable.Input = e.NewTextValue;
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
