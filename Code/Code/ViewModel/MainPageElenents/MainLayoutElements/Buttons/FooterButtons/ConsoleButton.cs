using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    public class ConsoleButton : BaseView
    {
        Button Button;
        public ConsoleButton()
        {
            Button = (Button)new FooterButton("Console").GetView();
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
