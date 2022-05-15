using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class WhileCycleButton : BaseView
    {
        private readonly Button Button;
        public WhileCycleButton(MainField MainField, StackLayout layoutToAddUnit, Button replaceButton = null)
        {
            Button = (Button)new SelectionButton("While", new Color(255 / 256.0, 0 / 256.0, 102 / 256.0)).GetView();
            Button.Clicked += (s, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new WhileCycleView(MainField).GetView());
                if (replaceButton != null) layoutToAddUnit.Children.Add(replaceButton);
                MainField.SetCodeField();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
