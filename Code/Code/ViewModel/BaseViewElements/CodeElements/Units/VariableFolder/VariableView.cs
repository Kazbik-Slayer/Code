using Xamarin.Forms;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Codeblock.Model;
using System;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder
{
    public class VariableView : DraggableElements
    {
        public Variable Variable;
        public VariableView(MainField mainField, StackLayout stackLayout, CodeBlock codeBlock) : base()
        {
            DragAndDropParentLayout = stackLayout;
            CodeBlock = codeBlock;
            MainField = mainField;
            Compose();
        }
        protected override void Compose()
        {
            Variable = new Variable(MainField);
            CodeBlock.AddVariable(Variable);
            StackLayout variableLayout = new StackLayout()
            { 
                Orientation = StackOrientation.Horizontal,
            };

            VariableTypePicker Type = new VariableTypePicker(new Color(171 / 255.0, 0 / 255.0, 34 / 255.0));
            SimpleUnitEntry Name = new SimpleUnitEntry("Name", new Color(171 / 255.0, 0 / 255.0, 34 / 255.0));
            SimpleUnitEntry Value = new SimpleUnitEntry("Value", new Color(171 / 255.0, 0 / 255.0, 34 / 255.0));

            Node = Variable;

            Type.TypePicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            Name.Entry.TextChanged += EntryNameChanged;
            Value.Entry.TextChanged += EntryValueChanged;

            variableLayout.Children.Add(Type.GetView());
            variableLayout.Children.Add(Name.GetView());
            variableLayout.Children.Add(Value.GetView());

            Frame DragAndDropFrame = (Frame) new SimpleUnitFrame(variableLayout, new Color(235 / 255.0, 0 / 255.0, 47 / 255.0)).GetView();

            DragAndDropLayout.Children.Add(DragAndDropFrame);
        }
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Variable.Type = picker.Items[selectedIndex];
            }
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
