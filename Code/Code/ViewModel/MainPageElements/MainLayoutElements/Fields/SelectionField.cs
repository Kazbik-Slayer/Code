﻿using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Fields
{
    public class SelectionField : BaseView
    {
        private StackLayout SelectionLayout;
        private MainField MainField;
        public SelectionField(MainField mainField)
        {
            MainField = mainField;

            SelectionLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = new Color(0 / 256.0, 48 / 256.0, 73 / 256.0),
            };
            Compose();
        }
        protected override void Compose()
        {
            StackLayout stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            stackLayout.Children.Add(new LogicButton(MainField, MainField.CodeField.MainBlockView.BlockElementsHolder).GetView());
            stackLayout.Children.Add(new VariableButton(MainField, MainField.CodeField.MainBlockView.BlockElementsHolder).GetView());
            stackLayout.Children.Add(new AssignmentButton(MainField, MainField.CodeField.MainBlockView.BlockElementsHolder).GetView());
            stackLayout.Children.Add(new OutputButton(MainField, MainField.CodeField.MainBlockView.BlockElementsHolder).GetView());
            stackLayout.Children.Add(new CancelButton(MainField).GetView());

            SelectionLayout.Children.Add(stackLayout);
        }
        public override View GetView()
        {
            return SelectionLayout;
        }
    }
}