using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class ArrayButton : BaseView
    {
        Button Button;
        public ArrayButton(MainField mainField, StackLayout layoutToAddUnit, Button replaceButton = null)
        {
            Button = (Button)new SelectionButton("Array", new Color(255 / 256.0, 0 / 256.0, 81 / 256.0)).GetView();
            Button.Clicked += (sender, e) =>
            {
                    if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                    layoutToAddUnit.Children.Add(new ArrayView(mainField, layoutToAddUnit).GetView());
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
