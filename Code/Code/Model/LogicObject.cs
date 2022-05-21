using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class LogicObject : Node
	{
		public CodeBlock Commands;

		public string Input;
		public string Boolean;
		public LogicObject(MainField mainField, CodeBlock CurrentCodeBlock, string input = "") : base()
		{
			MainField = mainField;
			Input = input;
			Commands = new CodeBlock(CurrentCodeBlock.AreaVariable, CurrentCodeBlock.AreaFunctions);
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			Console.WriteLine(Input);
			Console.WriteLine(Calculate(Input, "bool", CurrentCodeBlock));
			Console.WriteLine();
			Boolean = Calculate(Input, "bool", CurrentCodeBlock);
            if (Boolean == "true" && !CurrentCodeBlock.CompilationError)
            {
                Commands.Compilation();
            }
        }
	}
}