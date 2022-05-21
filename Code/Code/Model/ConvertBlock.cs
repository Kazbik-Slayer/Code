using App2.ViewModel.MainPageElenents.MainLayoutElements;
using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class ConvertBlock : Node
	{
		public string Name;
		public string InputType;
		public ConvertBlock(MainField mainField, string name = "", string inputType = "int") : base()
		{
			MainField = mainField;
			Name = name;
			InputType = inputType;
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			for (int i = CurrentCodeBlock.AreaVariable.Count - 1; i >= 0; i--)
			{
				for (int j = 0; j < CurrentCodeBlock.AreaVariable[i].Count; j++)
				{
					if (CurrentCodeBlock.AreaVariable[i][j].Name == Name)
					{
						if (CurrentCodeBlock.AreaVariable[i][j].Type == "int" && InputType == "double")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "int" && InputType == "bool")
						{
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None" && int.Parse(CurrentCodeBlock.AreaVariable[i][j].Value) > 0)
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = "true";
							}
                            else if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
                            {
								CurrentCodeBlock.AreaVariable[i][j].Value = "false";
                            }
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "int" && InputType == "string")
						{
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;
                        }
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "int" && InputType == "char")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = ((char)int.Parse(CurrentCodeBlock.AreaVariable[i][j].Value)).ToString();
							}
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "double" && InputType == "int")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = (Convert.ToInt32(Math.Floor(ParseToDouble(CurrentCodeBlock.AreaVariable[i][j].Value)))).ToString();
							}
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "double" && InputType == "bool")
						{
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None" && int.Parse(CurrentCodeBlock.AreaVariable[i][j].Value) > 0)
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = "true";
							}
							else if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = "false";
							}
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "double" && InputType == "string")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "double" && InputType == "char")
						{
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
							{
								CurrentCodeBlock.AreaVariable[i][j].Value = ((char)int.Parse(CurrentCodeBlock.AreaVariable[i][j].Value)).ToString();
							}
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "string" && InputType == "int")
						{
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							int a;
							if (int.TryParse(CurrentCodeBlock.AreaVariable[i][j].Value, out a))
                            {
								CurrentCodeBlock.AreaVariable[i][j].Value = a.ToString();
                            }
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "string" && InputType == "double")
						{
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							double a;
							if (double.TryParse(CurrentCodeBlock.AreaVariable[i][j].Value, out a))
                            {
								CurrentCodeBlock.AreaVariable[i][j].Value = a.ToString();
                            }
						}
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "string" && InputType == "char")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None" && CurrentCodeBlock.AreaVariable[i][j].Value.Length != 1)
                            {
								MainField.ConsoleWriteLine("Exception: String " + CurrentCodeBlock.AreaVariable[i][j].Value + " to char, because length of String isn't one");
								CurrentCodeBlock.Error();
                            }
                        }
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "char" && InputType == "int")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
                            {
								CurrentCodeBlock.AreaVariable[i][j].Value = ((int)CurrentCodeBlock.AreaVariable[i][j].Value[0]).ToString();
                            }
                        }
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "char" && InputType == "double")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;

							if (CurrentCodeBlock.AreaVariable[i][j].Value != "None")
                            {
								CurrentCodeBlock.AreaVariable[i][j].Value = ((int)CurrentCodeBlock.AreaVariable[i][j].Value[0]).ToString();
                            }
                        }
						else if (CurrentCodeBlock.AreaVariable[i][j].Type == "char" && InputType == "string")
                        {
							CurrentCodeBlock.AreaVariable[i][j].Type = InputType;
                        }
						i = -1;
						break;
					}
				}
				if (i == 0)
				{
					MainField.ConsoleWriteLine("Exception: " + Name + " is not found");
					CurrentCodeBlock.Error();
				}
			}
		}
	}
}