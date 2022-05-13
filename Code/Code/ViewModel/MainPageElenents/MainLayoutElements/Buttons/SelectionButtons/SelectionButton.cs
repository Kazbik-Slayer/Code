using System;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Buttons.SelectionButtons
{
    public class SelectionButton : BaseView
    {
        private Button SButton;
        public SelectionButton(string name, Color color)
        {
            SButton = new Button
            {
                Text = name,
                BackgroundColor = color,
                CornerRadius = 10,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
        }
        public override View GetView()
        {
            return SButton;
        }
    }
}
