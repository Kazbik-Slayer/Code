using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;
using System;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.ConverterFolder
{
    public class ConverterView : DraggableElements
    {
        public ConvertBlock ConvertBlock;
        public ConverterView(MainField mainField, StackLayout stackLayout, CodeBlock codeBlock) : base()
        {
            MainField = mainField;
            DragAndDropParentLayout = stackLayout;
            CodeBlock = codeBlock;
            Compose();
        }
        protected override void Compose()
        {
            ConvertBlock = new ConvertBlock(MainField);
            CodeBlock.AddConvertBlock(ConvertBlock);

            SimpleUnitEntry name = new SimpleUnitEntry("Name", new Color(179 / 256.0, 0 / 256.0, 101 / 256.0));
            VariableTypePicker newType = new VariableTypePicker(new Color(179 / 256.0, 0 / 256.0, 101 / 256.0));

            name.Entry.TextChanged += EntryNameChanged;
            newType.TypePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;

            Frame SUF = (Frame) new SimpleUnitFrame(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Margin = 0,
                Padding = 0,
                Children =
                {
                    name.GetView(),
                    newType.GetView(),
                }
            }, new Color(224 / 256.0, 0 / 256.0, 127 / 256.0)).GetView();

            DragAndDropLayout.Children.Add(SUF);
        }
        public void EntryNameChanged(object sender, TextChangedEventArgs e)
        {
            ConvertBlock.Name = e.NewTextValue;
        }
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                ConvertBlock.InputType = picker.Items[selectedIndex];
            }
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}
