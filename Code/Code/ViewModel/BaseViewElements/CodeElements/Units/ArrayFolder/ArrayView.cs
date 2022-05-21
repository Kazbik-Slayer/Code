using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class ArrayView : DraggableElements
    {
        public ArrayBlock ArrayBlock;
        public ArrayView(MainField mainField, StackLayout stackLayout, CodeBlock codeBlock) : base()
        {
            DragAndDropParentLayout = stackLayout;
            CodeBlock = codeBlock;
            MainField = mainField;
            Compose();
        }
        protected override void Compose()
        {
            ArrayBlock = new ArrayBlock(MainField);
            CodeBlock.AddArrayBlock(ArrayBlock);

            VariableTypePicker VTP = new VariableTypePicker(new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));
            SimpleUnitEntry Name = new SimpleUnitEntry("Name", new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));
            SimpleUnitEntry Length = new SimpleUnitEntry("Length", new Color(194 / 256.0, 0 / 256.0, 62 / 256.0));

            VTP.TypePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            Name.Entry.TextChanged += EntryNameChanged;
            Length.Entry.TextChanged += EntryLengthChanged;

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

            Values.Entry.TextChanged += EntryValueChanged;

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
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                ArrayBlock.Type = picker.Items[selectedIndex];
            }
        }
        public void EntryNameChanged(object sender, TextChangedEventArgs e)
        {
            ArrayBlock.Name = e.NewTextValue;
        }
        public void EntryLengthChanged(object sender, TextChangedEventArgs e)
        {
            ArrayBlock.Length = e.NewTextValue;
        }
        public void EntryValueChanged(object sender, TextChangedEventArgs e)
        {
            ArrayBlock.Input = e.NewTextValue;
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
