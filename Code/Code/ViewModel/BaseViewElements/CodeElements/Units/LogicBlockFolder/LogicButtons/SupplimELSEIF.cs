﻿using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.BaseViewElements.CodeElements.Units;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;
using Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts;
using Xamarin.Forms;

namespace Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicButtons
{
    class SupplimELSEIF : BaseView
    {
        private readonly Button Button;
        public SupplimELSEIF(MainField mainField, LogicBlockView logicBlockView)
        {
            Button = (Button)new SelectionButton("Else If", new Color(7 / 256.0, 186 / 256.0, 107 / 256.0)).GetView();
            Button.Clicked += (s, e) =>
            {
                ELSEIF eLSEIF = new ELSEIF(mainField, logicBlockView);
                if (logicBlockView.hasElse)
                {
                    BlockView BV = logicBlockView.BlockViewList[logicBlockView.BlockViewList.Count - 1];
                    logicBlockView.LogickBlockLayout.Children.Remove(BV.BlockElementsHolder);
                    logicBlockView.BlockViewList.Remove(BV);

                    logicBlockView.LogickBlockLayout.Children.Add(eLSEIF.GetView());
                    logicBlockView.BlockViewList.Add(eLSEIF.BlockView);

                    logicBlockView.LogickBlockLayout.Children.Add(BV.BlockElementsHolder);
                    logicBlockView.BlockViewList.Add(BV);
                }
                else
                {
                    logicBlockView.LogickBlockLayout.Children.Add(eLSEIF.GetView());
                    logicBlockView.BlockViewList.Add(eLSEIF.BlockView);
                }
                mainField.SetCodeField();
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}