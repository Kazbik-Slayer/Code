using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units.VariableFolder;
using System.Threading.Tasks;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class VariableButton : BaseView
    {
        private readonly MainField MainField;
        private readonly Button VButton;
        public VariableButton(MainField mainFiled)
        {
            MainField = mainFiled;
            VButton = (Button) new SelectionButton("Variable", new Color(171 / 255.0, 0 / 255.0, 34 / 255.0)).GetView();
            VButton.Clicked += AddVariable;
        }
        private void AddVariable(object sender, EventArgs e)
        {
            MainField.CodeField.MainBlockView.BlockElementsHolder.Children.Add(new VariableView().GetView());
            MainField.SetCodeFiled();
        }
        public override View GetView()
        {
            return VButton;
        }
    }
}
