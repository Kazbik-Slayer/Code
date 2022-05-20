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
            dragGestureRecognizer.DropCompleted += DragOver;
            dropGestureRecognizer.Drop += OnDrop;
            DragAndDropLayout.GestureRecognizers.Add(dragGestureRecognizer);
            DragAndDropLayout.GestureRecognizers.Add(dropGestureRecognizer);
        } 
        public void OnDrag(object sender, DragStartingEventArgs e)
        {
            e.Data.Properties.Add("Layout", DragAndDropLayout);
            e.Data.Properties.Add("ParentLayout", DragAndDropParentLayout);

            MainField.CodeField.Code.TranslateTo(0, 30, 150, Easing.SinOut);
            MainField.CodeField.RemovePlace.HeightRequest = 30;
            MainField.CodeField.RemovePlace.Children.Add(new Label()
            {
                Text = ":Drop here to remove",
                VerticalTextAlignment = TextAlignment.Center,
                Margin = 0,
                Padding = 0,
                FontSize = 22,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            });
        }

        public void DragOver(object sender, DropCompletedEventArgs e)
        {
            MainField.CodeField.RemovePlace.HeightRequest = 0;
            MainField.CodeField.Code.TranslateTo(0, 0, 150, Easing.SinOut);
            MainField.CodeField.RemovePlace.Children.Clear();
        }

        public void OnDrop(object sender, DropEventArgs e)
        {
            MainField.CodeField.RemovePlace.HeightRequest = 0;
            MainField.CodeField.Code.TranslateTo(0, 0, 150, Easing.SinOut);
            MainField.CodeField.RemovePlace.Children.Clear();
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
        }
    }
}
