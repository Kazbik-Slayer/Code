using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicButtons;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder
{
    public class SupplementButton : BaseView
    {
        private readonly Button Button;
        public SupplementButton(bool isLogic, MainField MainField, LogicBlockView logicBlockView, StackLayout stackLayout)
        {
            Button = new Button()
            {
                Text = "+",
                CornerRadius = 10,
                Padding = 0,
                Margin = 0,
                BackgroundColor = new Color(188 / 255.0, 23 / 255.0, 92 / 255.0),
                WidthRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
            };
            Button.Clicked += (s, e) =>
            {
                StackLayout ButtonsHolder = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };

                StackLayout Buttons = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                if (isLogic)
                {
                    Buttons.Children.Add(new SupplimELSEIF(MainField, logicBlockView).GetView());
                    if (!logicBlockView.hasElse)
                    {
                        Buttons.Children.Add(new SupplimELSE(MainField, logicBlockView).GetView());
                    }
                    Buttons.Children.Add(new CancelButton(MainField).GetView());
                }
                else
                {
                    Buttons.Children.Add(new LogicButton(MainField, stackLayout, Button).GetView());
                    Buttons.Children.Add(new VariableButton(MainField, stackLayout, Button).GetView());
                    Buttons.Children.Add(new AssignmentButton(MainField, stackLayout, Button).GetView());
                    Buttons.Children.Add(new OutputButton(MainField, stackLayout, Button).GetView());
                    Buttons.Children.Add(new CancelButton(MainField).GetView());
                }
                ButtonsHolder.Children.Add(Buttons);
                MainField.SetCustomField(ButtonsHolder);
            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
