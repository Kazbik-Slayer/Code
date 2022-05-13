using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class OutputButton : BaseView
    {
        private readonly Button Button;
        public OutputButton(MainField mainField)
        {
            Button = (Button) new SelectionButton("Output", new Color(189 / 256.0, 40 / 256.0, 117 / 256.0)).GetView();
            Button.Clicked += (sender, e) =>
            {
                mainField.CodeField.MainBlockView.BlockElementsHolder.Children.Add(new OutputView().GetView());
                mainField.SetCodeFiled();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
