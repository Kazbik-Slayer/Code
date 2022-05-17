using Xamarin.Forms;
using App2.ViewModel.MainPageElenents.MainLayoutElements;
using Code.ViewModel.BaseViewElements.CodeElements.Units.LogicBlockFolder.LogicBlockParts;
using System.Collections.Generic;
using App2.ViewModel.BaseViewElements.CodeElements.BlockViews;
using Codeblock.Model;

namespace App2.ViewModel.BaseViewElements.CodeElements.Units
{
    public class LogicBlockView : DraggableElements
    {
        public StackLayout LogickBlockLayout;
        public bool hasElse;
        public List<BlockView> BlockViewList;
        public LogicBlockView(MainField mainField, CodeBlock codeBlock) : base()
        {
            MainField = mainField;
            CodeBlock = codeBlock;
            hasElse = false;
            LogickBlockLayout = new StackLayout(){ Orientation = StackOrientation.Vertical };
            BlockViewList = new List<BlockView>();
            Frame frame = new Frame()
            {
                Content = LogickBlockLayout,
                Margin = 0,
                Padding = 1,
                CornerRadius = 10,
                BackgroundColor = new Color(38 / 256.0, 1 / 256.0, 117 / 256.0),
                BorderColor = new Color(19 / 256.0, 232 / 256.0, 143 / 256.0),
            };
            DragAndDropLayout.Children.Add(frame);
            Compose();
        }
        protected override void Compose()
        {
            IF_Block IF = new IF_Block(MainField, this, CodeBlock);
            BlockViewList.Add(IF.BlockView);
            LogickBlockLayout.Children.Add(IF.GetView());
        }
        public override View GetView()
        {
            return DragAndDropLayout;
        }
    }
}