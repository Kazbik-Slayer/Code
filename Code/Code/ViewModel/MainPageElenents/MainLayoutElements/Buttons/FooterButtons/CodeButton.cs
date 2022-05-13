using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons;
using Xamarin.Forms;

namespace Code.ViewModel.MainPageElenents.MainLayoutElements.Buttons.FooterButtons
{
    class CodeButton : BaseView
    {
        private readonly Button Button;
        public CodeButton(MainField mainField)
        {
            Button = (Button) new FooterButton("Code").GetView();
            Button.Clicked += (sender, e) =>
            {
                mainField.SetCodeFiled();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
