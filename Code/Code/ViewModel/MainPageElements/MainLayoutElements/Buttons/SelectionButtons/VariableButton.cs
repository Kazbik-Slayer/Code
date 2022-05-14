using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class VariableButton : BaseView
    {
        private readonly Button Button;
        public VariableButton(MainField mainField, StackLayout layoutToAddUnit, Button replaceButton = null)
        {
            Button = (Button) new SelectionButton("Variable", new Color(171 / 255.0, 0 / 255.0, 34 / 255.0)).GetView();
            Button.Clicked += (s, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new VariableView().GetView());
                if (replaceButton != null) layoutToAddUnit.Children.Add(replaceButton);
                mainField.SetCodeField();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
