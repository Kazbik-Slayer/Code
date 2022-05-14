using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class CancelButton : BaseView
    {
        private readonly Button Button;
        public CancelButton(MainField MainField)
        {
            Button = (Button) new SelectionButton("Cancel", new Color(188 / 255.0, 23 / 255.0, 92 / 255.0)).GetView();
            Button.Clicked += (s, e) =>
            {
                MainField.SetCodeField();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
