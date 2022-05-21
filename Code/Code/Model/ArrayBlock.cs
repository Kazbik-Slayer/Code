using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class ArrayBlock : Variable
	{
		//Name from Variable
		//Type from Variable
		public string Length;
		public int CurrentLength;
		public List<Variable> AreaVariable;
		public ArrayBlock(MainField mainField) : base(mainField)
		{
			CurrentLength = 0;
			Array = true;
			AreaVariable = new List<Variable>();
		}
		public void Initialization(CodeBlock CurrentCodeBlock)
		{
			CurrentLength = 0;
			for (int i = 0; i < Input.Length; i++)
            {
				string CurrentWord = "";

				while (i < Input.Length && Input[i] != ',')
                {
					CurrentWord += Input[i++];
                }

				AreaVariable.Add(new Variable(MainField, Name + "[" + CurrentLength + "]", Type, "", Calculate(CurrentWord, Type, CurrentCodeBlock)));
				CurrentLength++;

				if (CurrentLength > int.Parse(Length))
                {
					MainField.ConsoleWriteLine("Notice: So many Input Arguments to Array");
					break;
                }
			}
			for (int i = CurrentLength; i < int.Parse(Length); i++)
            {
				AreaVariable.Add(new Variable(MainField, Name + "[" + CurrentLength + "]", Type));
				CurrentLength++;
			}
		}
		public override Variable GetVariable(CodeBlock CurrentCodeBlock, string Index = "") 
		{
			if (int.Parse(Calculate(Index, "index", CurrentCodeBlock)) < int.Parse(Length) && int.Parse(Calculate(Index, "index", CurrentCodeBlock)) >= 0)
			{
				return AreaVariable[int.Parse(Calculate(Index, "index", CurrentCodeBlock))];
			}
            else
            {
				MainField.ConsoleWriteLine("Exception: index out of range array");
				CurrentCodeBlock.Error();
				return null;
            }
		}
		public override void WriteLineVariable(CodeBlock CurrentCodeBlock = null, string Index = "")
		{
			if (Index == "")
			{
				for (int i = 0; i < int.Parse(Length); i++)
				{
					AreaVariable[i].WriteLineVariable();
				}
			}
            else
            {
				if (int.Parse(Calculate(Index, "index", CurrentCodeBlock)) < int.Parse(Length) && int.Parse(Calculate(Index, "index", CurrentCodeBlock)) >= 0)
				{
					AreaVariable[int.Parse(Calculate(Index, "index", CurrentCodeBlock))].WriteLineVariable();
				}
				else
                {
					MainField.ConsoleWriteLine("Exception: index out of range array");
					CurrentCodeBlock.Error();
                }
            }
		}
		public override string GetValue(CodeBlock currentCodeBlock, string input = "")
		{
			return AreaVariable[int.Parse(Calculate(input, "index", currentCodeBlock))].GetValue(currentCodeBlock);
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			if (Assignment)
			{
				for (int i = CurrentCodeBlock.AreaVariable.Count - 1; i >= 0; i--)
				{
					for (int j = 0; j < CurrentCodeBlock.AreaVariable[i].Count; j++)
					{
						if (CurrentCodeBlock.AreaVariable[i][j].Name == Name && CurrentCodeBlock.AreaVariable[i][j].Type == Type && CurrentCodeBlock.AreaVariable[i][j].Array)
						{
							for (int l = CurrentCodeBlock.AreaVariable.Count - 1; l >= 0; l--)
							{
								for (int k = 0; k < CurrentCodeBlock.AreaVariable[l].Count; k++)
								{
									if (CurrentCodeBlock.AreaVariable[l][k].Name == Input && CurrentCodeBlock.AreaVariable[l][k].Type == Type && CurrentCodeBlock.AreaVariable[i][j].Array)
									{
										CurrentCodeBlock.AreaVariable[i][j] = CurrentCodeBlock.AreaVariable[l][k];
										l = -1;
										break;
									}
								}
								if (l == 0)
                                {
									MainField.ConsoleWriteLine("Exception: " + Input + " is undefined");
									CurrentCodeBlock.Error();
								}
							}
							i = -1;
							break;
						}
					}
					if (i == 0)
					{
						MainField.ConsoleWriteLine("Exception: " + Name + " is undefined");
						CurrentCodeBlock.Error();
					}
				}
			}
			else
			{
				Initialization(CurrentCodeBlock);
			}
		}
	}
}