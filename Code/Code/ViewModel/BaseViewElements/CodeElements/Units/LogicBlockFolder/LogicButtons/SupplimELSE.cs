using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;
using Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts;
using Codeblock.Model;
using Xamarin.Forms;

namespace Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicButtons
{
    class SupplimELSE : BaseView
    {
        private readonly Button Button;
        public SupplimELSE(MainField mainField, LogicBlockView logicBlockView, CodeBlock codeBlock)
        {
            Button = (Button) new SelectionButton("Else", new Color(7 / 256.0, 186 / 256.0, 107 / 256.0)).GetView();
            Button.Clicked += (s, e) =>
            {
                logicBlockView.LogickBlockLayout.Children.Add(new ELSE(mainField, logicBlockView, codeBlock).GetView());
                logicBlockView.hasElse = true;
                mainField.SetCodeField();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
