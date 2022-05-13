using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class CancelButton : BaseView
    {
        private readonly Button Button;
        private readonly MainField MainField;
        public CancelButton(MainField mainField)
        {
            MainField = mainField;
            Button = (Button) new SelectionButton("Cancel", new Color(188 / 255.0, 23 / 255.0, 92 / 255.0)).GetView();
            Button.Clicked += Cancel;
        }
        private void Cancel(object sender, EventArgs e)
        {
            MainField.SetCodeFiled();
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
