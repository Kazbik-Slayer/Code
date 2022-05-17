using System;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder
{
    public class VariableTypePicker : BaseView
    {
        public Picker TypePicker;
        private Frame Frame;
        public VariableTypePicker(Color color)
        {
            TypePicker = new Picker()
            {
                BackgroundColor = color,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                Title = "Type",
                Margin = 0,
            };
            TypePicker.Items.Add("int");
            TypePicker.Items.Add("double");
            TypePicker.Items.Add("char");
            TypePicker.Items.Add("string");
            TypePicker.Items.Add("bool");
            Frame = new Frame()
            {
                Content = TypePicker,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = color,
                CornerRadius = 10,
                Margin = 0,
                Padding = 0,
            };
        }
        public override View GetView()
        {
            return Frame;
        }
    }
}
