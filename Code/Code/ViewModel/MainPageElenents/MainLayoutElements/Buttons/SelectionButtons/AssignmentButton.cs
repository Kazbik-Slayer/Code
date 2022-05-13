using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class AssignmentButton : BaseView
    {
        private readonly Button Button;
        public AssignmentButton(MainField mainField)
        {
            Button = (Button) new SelectionButton("Assignment", new Color(189 / 256.0, 0 / 256.0, 66 / 256.0)).GetView();
            Button.Clicked += (sender, e) =>
            {
                mainField.CodeField.MainBlockView.BlockElementsHolder.Children.Add(new AssignmentView().GetView());
                mainField.SetCodeFiled();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
