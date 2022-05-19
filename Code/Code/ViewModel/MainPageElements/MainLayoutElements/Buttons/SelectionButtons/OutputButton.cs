using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using Codeblock.Model;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class OutputButton : BaseView
    {
        private readonly Button Button;
        public OutputButton(MainField mainField, StackLayout layoutToAddUnit, CodeBlock codeBlock, Button replaceButton = null)
        {
            Button = (Button) new SelectionButton("Output", new Color(189 / 256.0, 40 / 256.0, 117 / 256.0)).GetView();
            Button.Clicked += (sender, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new OutputView(mainField, layoutToAddUnit, codeBlock).GetView());
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
