using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class AssignmentView : DraggableElements
    {
        private readonly Frame Frame;
        public AssignmentView() : base()
        {
            Frame = (Frame) new SimpleUnitFrame(new StackLayout()
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
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
