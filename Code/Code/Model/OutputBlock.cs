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
                string CurrentIndex = "";

                while (l < Input.Length && Input[l] != ' ' && Input[l] != ',')
                {
                    if (Input[l] == '[')
                    {
                        int count = -1;
                        while (Input[l] != ']' || count > 0)
                        {
                            if (Input[l] == '[')
                            {
                                count++;
                            }
                            if (Input[l] == ']')
                            {
                                count--;
                            }
                            CurrentIndex += Input[l++];
                        }
                        CurrentIndex += Input[l++];
                        break;
                    }
                    else
                    {
                        CurrentName += Input[l++];
                    }
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
                            CurrentCodeBlock.AreaVariable[i][j].WriteLineVariable(CurrentCodeBlock, CurrentIndex);
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