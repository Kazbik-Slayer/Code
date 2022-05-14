using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Fields;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    public class AdditionButton : BaseView
    {
        private readonly Button Button;
        private readonly MainField MainField;
        public AdditionButton(MainField mainField)
        {
            MainField = mainField;
            Button = (Button)new FooterButton("Add").GetView();
            Button.Clicked += OpenSelectionBar;
        }
        private void OpenSelectionBar(object sender, EventArgs e)
        {
            MainField.SetSelectionView();
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
