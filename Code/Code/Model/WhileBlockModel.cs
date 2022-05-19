using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class WhileBlockModel : Node
	{
		public LogicObject CurrentLogicObject;
		public WhileBlockModel(MainField mainField, CodeBlock currentCodeBlock) : base()
        {
			MainField = mainField;
			CurrentLogicObject = new LogicObject(mainField, currentCodeBlock);
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			int count = 0;
			while (Calculate(CurrentLogicObject.Input, "bool", CurrentCodeBlock) == "true")
            {
				CurrentLogicObject.Commands.Compilation();
				count++;
				if (count > 300)
                {
					MainField.ConsoleWriteLine("Exception: While has out of 300 iteration");
					CurrentCodeBlock.Error();
					break;
                }
				if (CurrentLogicObject.Commands.CompilationError)
                {
					CurrentCodeBlock.Error();
					break;
				}
            }
		}
	}
}