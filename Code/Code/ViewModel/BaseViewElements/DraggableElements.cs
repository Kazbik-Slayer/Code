﻿using Xamarin.Forms;
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
            DragAndDropLayout = new StackLayout();
            DragGestureRecognizer dragGestureRecognizer = new DragGestureRecognizer();
            DropGestureRecognizer dropGestureRecognizer = new DropGestureRecognizer();
            dragGestureRecognizer.DragStarting += OnDrag;
            dragGestureRecognizer.DropCompleted += OnDrop;
            DragAndDropLayout.GestureRecognizers.Add(dragGestureRecognizer);
            DragAndDropLayout.GestureRecognizers.Add(dropGestureRecognizer);
        }
        public void OnDrag(object sender, DragStartingEventArgs e)
        {
            foreach(View CurrentView in DragAndDropParentLayout.Children)
            {
                if (DragAndDropLayout == CurrentView)
                {
                    DragAndDropParentLayout.Children.Remove(CurrentView);
                }
            }
        }
        public void OnDrop(object sender, DropCompletedEventArgs e)
        {

        }
    }
}
