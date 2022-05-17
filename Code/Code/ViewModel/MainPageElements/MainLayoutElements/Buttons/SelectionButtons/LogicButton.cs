using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using Codeblock.Model;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class LogicButton : BaseView
    {
        private readonly Button Button;
        public LogicButton(MainField MainField, StackLayout layoutToAddUnit, CodeBlock codeBlock, Button replaceButton = null)
        {
            Button = (Button) new SelectionButton("Logic", new Color(8 / 256.0, 196 / 256.0, 112 / 256.0)).GetView();
            Button.Clicked += (s, e) =>
            {
                if (replaceButton != null) layoutToAddUnit.Children.Remove(replaceButton);
                layoutToAddUnit.Children.Add(new LogicBlockView(MainField, codeBlock).GetView());
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
