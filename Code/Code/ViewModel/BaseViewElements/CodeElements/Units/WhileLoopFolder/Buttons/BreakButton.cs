using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;
using System;
using Xamarin.Forms;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.WhileLoopFolder.Buttons
{
    public class BreakButton : BaseView
    {
        Button Button;
        public BreakButton(MainField mainField, StackLayout layoutToAddUnit, Button replaceButton = null)
        {
            Button = (Button)new SelectionButton("Break", new Color()).GetView();
            Button.Clicked += (s, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new Break().GetView());
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
