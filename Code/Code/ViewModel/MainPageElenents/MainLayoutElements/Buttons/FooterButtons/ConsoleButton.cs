using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    public class ConsoleButton : BaseView
    {
        Button Button;
        public ConsoleButton(MainField mainField)
        {
            Button = (Button)new FooterButton("Console").GetView();
            Button.Clicked += (s, e) =>
            {
                mainField.SetConsoleField();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
