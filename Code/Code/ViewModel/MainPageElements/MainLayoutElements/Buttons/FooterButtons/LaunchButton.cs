using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    public class LaunchButton : BaseView
    {        
        Button Button;
        public LaunchButton()
        {
            Button = (Button)new FooterButton("Launch").GetView();
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
