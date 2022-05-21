using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.ConverterFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;
using Codeblock.Model;
using Xamarin.Forms;

namespace Code.ViewModel.MainPageElements.MainLayoutElements.Buttons.SelectionButtons
{
    public class SwapButton : BaseView
    {
        private Button Button;
        public SwapButton(MainField mainField, StackLayout layoutToAddUnit, CodeBlock codeBlock, Button replaceButton = null)
        {
            Button = (Button)new SelectionButton("Swap", new Color(255 / 256.0, 0 / 256.0, 76 / 256.0)).GetView();
            Button.Clicked += (sender, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new SwapView(mainField, layoutToAddUnit, codeBlock).GetView());
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
