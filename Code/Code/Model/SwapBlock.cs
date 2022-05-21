using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class SwapBlock : Node
	{
		public string InputFirst;
		public string InputSecond; 
		public SwapBlock(MainField mainField) : base()
		{
			MainField = mainField;
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			string CurrentNameFirst = "";
			string CurrentIndexFirst = "";

			string CurrentNameSecond = "";
			string CurrentIndexSecond = "";
			
			int index = 0;
			while (index < InputFirst.Length)
			{
				while (index < InputFirst.Length && InputFirst[index] != ' ' && InputFirst[index] != ',')
				{
					if (InputFirst[index] == '[')
					{
						int count = -1;
						while (InputFirst[index] != ']' || count > 0)
						{
							if (InputFirst[index] == '[')
							{
								count++;
							}
							if (InputFirst[index] == ']')
							{
								count--;
							}
							CurrentIndexFirst += InputFirst[index++];
						}
						CurrentIndexFirst += InputFirst[index++];
						break;
					}
					else
					{
						CurrentNameFirst += InputFirst[index++];
					}
				}
				index++;
			}

			index = 0;
			while (index < InputSecond.Length)
			{

				while (index < InputSecond.Length && InputSecond[index] != ' ' && InputSecond[index] != ',')
				{
					if (InputSecond[index] == '[')
					{
						int count = -1;
						while (InputSecond[index] != ']' || count > 0)
						{
							if (InputSecond[index] == '[')
							{
								count++;
							}
							if (InputSecond[index] == ']')
							{
								count--;
							}
							CurrentIndexSecond += InputSecond[index++];
						}
						CurrentIndexSecond += InputSecond[index++];
						break;
					}
					else
					{
						CurrentNameSecond += InputSecond[index++];
					}
				}
				index++;
			}
			Console.WriteLine("AHahahah");
			Console.WriteLine("CurrentNameFirst = " + CurrentNameFirst);
			Console.WriteLine("CurrentIndexFirst = " + CurrentIndexFirst);
			Console.WriteLine("CurrentNameSecond = " + CurrentNameSecond);
			Console.WriteLine("CurrentIndexSecond = " + CurrentIndexSecond);

			for (int i = CurrentCodeBlock.AreaVariable.Count - 1; i >= 0; i--)
			{
				for (int j = 0; j < CurrentCodeBlock.AreaVariable[i].Count; j++)
				{
					if (CurrentCodeBlock.AreaVariable[i][j].Name == CurrentNameFirst)
					{
						for (int k = CurrentCodeBlock.AreaVariable.Count - 1; k >= 0; k--)
						{
							for (int l = 0; l < CurrentCodeBlock.AreaVariable[k].Count; l++)
							{
								if (CurrentCodeBlock.AreaVariable[k][l].Name == CurrentNameSecond)
								{
									(CurrentCodeBlock.AreaVariable[i][j].GetVariable(CurrentCodeBlock, CurrentIndexFirst).Value, CurrentCodeBlock.AreaVariable[k][l].GetVariable(CurrentCodeBlock, CurrentIndexSecond).Value) = (CurrentCodeBlock.AreaVariable[k][l].GetVariable(CurrentCodeBlock, CurrentIndexSecond).Value, CurrentCodeBlock.AreaVariable[i][j].GetVariable(CurrentCodeBlock, CurrentIndexFirst).Value);
									(CurrentCodeBlock.AreaVariable[i][j].GetVariable(CurrentCodeBlock, CurrentIndexFirst).Type, CurrentCodeBlock.AreaVariable[k][l].GetVariable(CurrentCodeBlock, CurrentIndexSecond).Type) = (CurrentCodeBlock.AreaVariable[k][l].GetVariable(CurrentCodeBlock, CurrentIndexSecond).Type, CurrentCodeBlock.AreaVariable[i][j].GetVariable(CurrentCodeBlock, CurrentIndexFirst).Type);
									k = -1;
									break;
								}
							}
							if (k == 0)
							{
								MainField.ConsoleWriteLine("Exception: " + InputSecond + " is not found");
								CurrentCodeBlock.Error();
							}
						}
						i = -1;
						break;
					}
				}
				if (i == 0)
				{
					MainField.ConsoleWriteLine("Exception: " + InputFirst + " is not found");
					CurrentCodeBlock.Error();
				}
			}
		}
	}
}