using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using Xamarin.Forms;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class LogicButton : BaseView
    {
        private readonly Button Button;
        public LogicButton(MainField MainField)
        {
            Button = (Button) new SelectionButton("Logic", new Color(0)).GetView();
            Button.Clicked += (s, e) =>
            {
               //MainField.CodeField.MainBlockView.BlockElementsHolder.Children.Add(new LogicBlockView().GetView());
                MainField.SetCodeFiled();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
