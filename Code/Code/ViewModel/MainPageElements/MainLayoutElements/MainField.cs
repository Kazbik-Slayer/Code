using Xamarin.Forms;
using App2.ViewModel.BaseViewElements;
using App2.ViewModel.MainPageElenents.MainLayoutElements.Fields;

namespace App2.ViewModel.MainPageElenents.MainLayoutElements
{
    public class MainField : BaseView
    {
        public StackLayout MainFieldView;
        public CodeField CodeField;
        public ConsoleField ConsoleField;
        public SelectionField SelectionField;
        public MainField()
        {
            MainFieldView = new StackLayout() 
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            CodeField = new CodeField();
            ConsoleField = new ConsoleField();
            SelectionField = new SelectionField(this);
            SetCodeField();
        }
        public void SetCustomField(View View)
        {
            MainFieldView.Children.Clear();
            MainFieldView.Children.Add(View);
        }
        public void SetCodeField()
        {
            MainFieldView.Children.Clear();
            MainFieldView.Children.Add(CodeField.GetView());
        }
        public void SetConsoleField()
        {
            MainFieldView.Children.Clear();
            MainFieldView.Children.Add(ConsoleField.GetView());
        }
        public void SetSelectionView()
        {
            MainFieldView.Children.Clear();
            MainFieldView.Children.Add(SelectionField.GetView());
        }
        public override View GetView()
        {
            return MainFieldView;
        }
    }
}
