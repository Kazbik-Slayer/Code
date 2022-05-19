using System;
using Xamarin.Forms;
using System.Collections.Generic;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using Codeblock.Model;

namespace App2.ViewModel.BaseViewElements
{
    public class DraggableElements : BaseView
    {
        public List<StackLayout> DraggableElementsList;
        public StackLayout DragAndDropParentLayout;
        public StackLayout DragAndDropLayout;
        public MainField MainField;
        public CodeBlock CodeBlock;
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
            e.Data.Properties.Add("Layout", DragAndDropLayout);
            e.Data.Properties.Add("ParentLayout", DragAndDropParentLayout);
        }
        public void OnDrop(object sender, DropEventArgs e)
        {
            if ((StackLayout)e.Data.Properties["Layout"] == DragAndDropLayout)
            {
                var stackLayout = (StackLayout)e.Data.Properties["Layout"];
                new StackLayout().Children.Add(stackLayout);
                ((StackLayout)e.Data.Properties["ParentLayout"]).Children.Remove(stackLayout);
                
                for (int i = 0; i < DragAndDropParentLayout.Children.Count; i++)
                {
                    if (DragAndDropParentLayout.Children[i] == DragAndDropLayout)
                    {
                        DragAndDropParentLayout.Children.Insert(i, stackLayout);
                        break;
                    }
                }
            }
            /*
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
            */
        }
    }
}
