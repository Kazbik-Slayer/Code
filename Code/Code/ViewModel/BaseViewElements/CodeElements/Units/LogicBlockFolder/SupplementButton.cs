using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder
{
    public class SupplementButton : BaseView
    {
        private readonly Button Button;
        private readonly bool IsLogic;
        private readonly MainField MainField;
        public SupplementButton(bool isLogic, MainField mainField, StackLayout layoutToAdd)
        {
            IsLogic = isLogic;
            MainField = mainField;
            Button = new Button()
            {
                Text = "+",
                CornerRadius = 10,
                Padding = 0,
                BackgroundColor = new Color(188 / 255.0, 23 / 255.0, 92 / 255.0),
            };
            Button.Clicked += (s, e) =>
            {

            };
        }
        public override View GetView()
        {
            return Button;
        }
    }
}
