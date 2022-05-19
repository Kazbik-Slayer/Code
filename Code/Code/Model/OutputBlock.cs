using System;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace Codeblock.Model
{
	public class OutputBlock : Node
	{
		public string Input;
		public OutputBlock(MainField mainField, string input = "") : base()
		{
			Input = input;
			MainField = mainField;
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			int l = 0;
			while (l < Input.Length)
			{
                string CurrentName = "";

                while (l < Input.Length && Input[l] != ' ' && Input[l] != ',')
                {
                    CurrentName += Input[l++];
                }

                if (CurrentName == "")
                {
                    l++;
                    continue;
                }

                for (int i = CurrentCodeBlock.AreaVariable.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < CurrentCodeBlock.AreaVariable[i].Count; j++)
                    {
                        if (CurrentCodeBlock.AreaVariable[i][j].Name == CurrentName)
                        {
                            CurrentCodeBlock.AreaVariable[i][j].WriteLineVariable();
                            i = -1;
                            break;
                        }
                    }
                    if (i == 0)
                    {
                        MainField.ConsoleWriteLine("Exception: " + CurrentName + " is undefined");
                        CurrentCodeBlock.Error();
                    }
                }
                l++;

            }
        }
	}
}