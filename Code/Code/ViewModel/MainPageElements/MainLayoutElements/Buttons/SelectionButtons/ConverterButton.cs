using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.ConverterFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;
using Xamarin.Forms;

namespace Code.ViewModel.MainPageElements.MainLayoutElements.Buttons.SelectionButtons
{
    public class ConverterButton : BaseView
    {
        private Button Button;
        public ConverterButton(MainField mainField, StackLayout layoutToAddUnit, Button replaceButton = null)
        {
            Button = (Button)new SelectionButton("Convert", new Color(224 / 256.0, 0 / 256.0, 127 / 256.0)).GetView();
            Button.Clicked += (sender, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new ConverterView(mainField).GetView());
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
