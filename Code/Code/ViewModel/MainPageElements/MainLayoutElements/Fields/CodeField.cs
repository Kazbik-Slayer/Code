using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using System;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements.Fields
{
    public class CodeField : BaseView
    {
        private readonly StackLayout CodeFieldLayout;
        public StackLayout RemovePlace;
        private readonly ScrollView ScrollView;
        public MainBlockView MainBlockView;
        public StackLayout Code;
        private DropGestureRecognizer DropGestureRecognizer;
        public CodeField()
        {
            CodeFieldLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = new Color(0 / 255.0, 83 / 255.0, 149 / 255.0),
                Spacing = 0,
                Padding = 0,
                Margin = 0,
            };
            RemovePlace = new StackLayout()
            {
                Margin = 0,
                Padding = 0,
                Spacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            ScrollView = new ScrollView()
            {
                Content = CodeFieldLayout,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            Code = new StackLayout()
            {
                Margin = 0,
                Padding = 0,
                Spacing = 0,
                HeightRequest = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    RemovePlace,
                    ScrollView,
                }
            };
            DropGestureRecognizer = new DropGestureRecognizer()
            {
                AllowDrop = true,
            };
            DropGestureRecognizer.Drop += Remove;

            RemovePlace.GestureRecognizers.Add(DropGestureRecognizer);
            Compose();
        }
        private void Remove(object sender, DropEventArgs e)
        {
            var stackLayout = (StackLayout)e.Data.Properties["Layout"];
            new StackLayout().Children.Add(stackLayout);
            ((StackLayout)e.Data.Properties["ParentLayout"]).Children.Remove(stackLayout);
            Console.WriteLine(":d");
        }
        protected override void Compose()
        {
            MainBlockView = new MainBlockView();
            CodeFieldLayout.Children.Add(MainBlockView.GetView());
        }
        public override View GetView()
        {
            return Code;
        }
    }
}
