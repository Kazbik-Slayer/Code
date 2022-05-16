using Xamarin.Forms;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace App2.ViewModel.BaseViewElements
{
    public class DraggableElements : BaseView
    {
          
        public StackLayout DragAndDropParentLayout;
        public StackLayout DragAndDropLayout;
        public MainField MainField;
        public DraggableElements()
        {
            AddDraggableElements();
        }
        public void AddDraggableElements()
        {
            DragAndDropLayout = new StackLayout() { Padding = 3.25 };
            DragGestureRecognizer dragGestureRecognizer = new DragGestureRecognizer();
            DropGestureRecognizer dropGestureRecognizer = new DropGestureRecognizer();
            dragGestureRecognizer.DragStarting += OnDrag;
            dropGestureRecognizer.Drop += OnDrop;
            DragAndDropLayout.GestureRecognizers.Add(dragGestureRecognizer);
            DragAndDropLayout.GestureRecognizers.Add(dropGestureRecognizer);
        } 
        public void OnDrag(object sender, DragStartingEventArgs e)
        {
            e.Data.Properties.Add("layout", DragAndDropLayout);
        }
        public void OnDrop(object sender, DropEventArgs e)
        {
            var stackLayout = (StackLayout)e.Data.Properties["layout"]; 
            new StackLayout().Children.Add(stackLayout);
            if (stackLayout != DragAndDropLayout)
            {
                DragAndDropParentLayout.Children.Remove(stackLayout);
                for (int i = 0; i < DragAndDropParentLayout.Children.Count; i++)
                {
                    if (DragAndDropParentLayout.Children[i] == DragAndDropLayout)
                    {
                        DragAndDropParentLayout.Children.Insert(i, stackLayout);
                        break;
                    }
                }
            }
        }
    }
}
