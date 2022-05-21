using System;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace Codeblock.Model
{
	public class Variable : Node
	{
		public string Name;
		public string Type;
		public string Input;
		public string Value;
		public bool Assignment = false;
		public bool Array = false;
		public Variable(MainField mainField, string name = "", string type = "int", string input = "", string value = "None") : base()
		{
			Name = name;
			Type = type;
			Input = input;
			Value = value;
			MainField = mainField;
		}
		public virtual Variable GetVariable(CodeBlock CurrentCodeBlock, string Index = "") { return this; }
		public virtual void WriteLineVariable(CodeBlock CurrentCodeBlock = null, string Index = "")
		{
			MainField.ConsoleWriteLine(Name + " = " + Value);
		}
		public virtual string GetValue(CodeBlock CurrentCodeBlock, string input = "")
		{
			if (input != "" && Type == "string")
			{
				if (Calculate(input, "index", CurrentCodeBlock) != "None" && int.Parse(Calculate(input, "index", CurrentCodeBlock)) < Value.Length && int.Parse(Calculate(input, "index", CurrentCodeBlock)) >= 0)
				{
					return Value[int.Parse(Calculate(input, "index", CurrentCodeBlock))].ToString();
				}
				else
				{
					MainField.ConsoleWriteLine("Exception: " + Value + " index out of range");
					CurrentCodeBlock.Error();
					return "None";
				}
			}
			else
			{
				return Value;
			}
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			if (Assignment)
			{
				string CurrentName = "";
				string CurrentIndex = "";

				int l = 0;
				while (l < Name.Length && Name[l] != ' ' && Name[l] != ',')
				{
					if (l < Name.Length && Name[l] == '[')
					{
						int count = -1;
						while (l < Name.Length && (Name[l] != ']' || count > 0))
						{
							if (Name[l] == '[')
							{
								count++;
							}
							if (Name[l] == ']')
							{
								count--;
							}
							CurrentIndex += Name[l++];
						}
						if (l == Name.Length) break;
						CurrentIndex += Name[l++];
						break;
					}
					else
					{
						CurrentName += Name[l++];
					}
				}

				for (int i = CurrentCodeBlock.AreaVariable.Count - 1; i >= 0; i--)
				{
					for (int j = 0; j < CurrentCodeBlock.AreaVariable[i].Count; j++)
					{
						if (CurrentCodeBlock.AreaVariable[i][j].Name == CurrentName)
						{
							if (CurrentIndex == "")
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = Calculate(Input, Type, CurrentCodeBlock);
								i = -1;
								break;
							}
                            else
                            {
								CurrentCodeBlock.AreaVariable[i][j].GetVariable(CurrentCodeBlock, CurrentIndex).Value = Calculate(Input, Type, CurrentCodeBlock);
								i = -1;
								break;
							}
						}
					}
					if (i == 0)
					{
						MainField.ConsoleWriteLine("Exception: " + CurrentName + " is not found");
						CurrentCodeBlock.Error();
					}
				}
			}
			else
			{
				if (Input != "")
				{
					Value = Calculate(Input, Type, CurrentCodeBlock);
				}

				bool NewVariable = true;
				for (int i = 0; i < CurrentCodeBlock.AreaVariable[CurrentCodeBlock.AreaVariable.Count - 1].Count; i++)
				{
					if (CurrentCodeBlock.AreaVariable[CurrentCodeBlock.AreaVariable.Count - 1][i].Name == Name)
					{
						CurrentCodeBlock.AreaVariable[CurrentCodeBlock.AreaVariable.Count - 1][i] = this;
						NewVariable = false;
						break;
					}
				}
				if (NewVariable)
				{
					CurrentCodeBlock.AreaVariable[CurrentCodeBlock.AreaVariable.Count - 1].Add(this);
				}
			}
		}
	}
}