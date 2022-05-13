using System.Collections.Generic;
using Xamarin.Forms;
using App2.ViewModel.BaseViewElements.CodeElements.BlcokViews;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using App2.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class LogicBlockView : BaseView
    {
        private readonly List<BlockView> ExpBlockList;
        private readonly List<Entry> ExpressionsList;
        private readonly StackLayout LogickBlockLayout;
        private readonly Frame LogicEntryFrame;
        private readonly MainBlockView MainBlock;
        private readonly MainField MainField;
        public LogicBlockView(MainBlockView block, MainField mainField)
        {
            MainBlock = block;
            MainField = mainField;

            ExpBlockList = new List<BlockView>();
            ExpressionsList = new List<Entry>();

            LogickBlockLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };
            Compose();
        }
        protected override void Compose()
        {
            BlockView blockView = new BlockView();
            StackLayout stackLayout = (StackLayout)blockView.GetView();

            SimpleUnitLabel SEL = new SimpleUnitLabel("If");
            SimpleUnitEntry SUE = new SimpleUnitEntry("Expressions", new Color(0 / 256.0, 170 / 256.0, 94 / 256.0));
            SupplementButton LogicSButtton = new SupplementButton(true, MainField, stackLayout);//TODO: удалить ненужные аргументы из конструктора

            blockView.BlockElementsHolder.Children.Add(new Frame()
            {
                Content = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        SEL.GetView(),
                        SUE.GetView(),
                        LogicSButtton.GetView(),
                    }
                },
            });

            blockView.BlockElementsHolder.Children.Add(new SupplementButton(false, MainField, stackLayout).GetView());
            //LogickBlockLayout.Children.Add();
            ExpBlockList.Add(blockView);
        }
        public override View GetView()
        {
            return LogicEntryFrame;
        }
    }
}
