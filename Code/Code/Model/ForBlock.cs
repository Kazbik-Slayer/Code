﻿using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class ForBlock : Node
	{
		Variable CurrentVariable;
		LogicObject CurrentLogicObject;
		Variable CurrentAssignment;
		public ForBlock(CodeBlock currentCodeBlock) : base()
		{
			CurrentVariable = new Variable(MainField);
			currentCodeBlock.AreaVariable[currentCodeBlock.AreaVariable.Count - 1].Add(CurrentVariable);
			CurrentLogicObject = new LogicObject(MainField, currentCodeBlock);
			CurrentAssignment = new Variable(MainField);
			CurrentAssignment.Assignment = true;
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			while (Calculate(CurrentLogicObject.Input, "bool", CurrentCodeBlock) == "true" && CurrentCodeBlock.CompilationError)
			{
				CurrentLogicObject.Commands.Compilation();

				if (CurrentLogicObject.Commands.CompilationError)
                {
					CurrentCodeBlock.Error();
					break;
				}

				CurrentAssignment.Compilation(CurrentCodeBlock);
			}
		}
	}
}