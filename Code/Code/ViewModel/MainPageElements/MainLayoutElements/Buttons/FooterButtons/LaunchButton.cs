using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    public class LaunchButton : BaseView
    {        
        Button Button;
        public LaunchButton(MainField mainField)
        {
            Button = (Button)new FooterButton("Launch").GetView();
            Button.Clicked += (s, e) =>
            {
                mainField.LaunchCommands();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
