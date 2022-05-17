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
        }
    }
}
