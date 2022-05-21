using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class CodeBlock : Node
	{
		public List<List<Variable>> AreaVariable;
		public List<CodeBlock> AreaFunctions;
		public List<Node> AreaCommands = new List<Node>();

		public string Name = "Main";
		public string Output = "";
		public string Type = "";

		public bool IsStartCodeBlock;
		public bool IsFunction = false;

		public bool CompilationError = false;

		public CodeBlock(List<List<Variable>> areaVariable, List<CodeBlock> areaFunctions, bool isStartCodeBlock = false) : base()
		{
			AreaVariable = areaVariable;
			AreaFunctions = areaFunctions;
			AreaVariable.Add(new List<Variable>());
			IsStartCodeBlock = isStartCodeBlock;
		}
		public void AddVariable(Variable variable)
		{
			AreaVariable[AreaVariable.Count - 1].Add(variable);
			AreaCommands.Add(variable);
		}
		public void AddAssignment(Variable variable)
		{
			variable.Assignment = true;
			AreaCommands.Add(variable);
		}
		public void AddLogicBlock(LogicBlock logicBlock)
		{
			AreaCommands.Add(logicBlock);
		}
		public void AddWhileBlockModel(WhileBlockModel whileBlockModel)
		{
			AreaCommands.Add(whileBlockModel);
		}
		public void AddForBlock()
		{
			ForBlock CurrentForBlock = new ForBlock(this);
			AreaCommands.Add(CurrentForBlock);
		}
		public void AddArrayBlock(ArrayBlock arrayBlock)
		{
			arrayBlock.Array = true;
			AreaVariable[AreaVariable.Count - 1].Add(arrayBlock);
			AreaCommands.Add(arrayBlock);
		}
		public void AddConvertBlock(ConvertBlock convertBlock)
        {
			AreaCommands.Add(convertBlock);
        }
		public void AddSwapBlock(SwapBlock swapBlock)
		{
			AreaCommands.Add(swapBlock);
		}
		public void AddOutputBlock(OutputBlock outputBlock)
		{
			AreaCommands.Add(outputBlock);
		}
		public void Compilation()
		{
			AreaVariable.Add(new List<Variable>());
			for (int i = 0; i < AreaCommands.Count; i++)
			{
				Console.WriteLine(AreaCommands[i]);
				AreaCommands[i].Compilation(this);
				if (CompilationError) break;
			}
			if (AreaVariable.Count != 0 && !IsStartCodeBlock)
			{
				AreaVariable.RemoveAt(AreaVariable.Count - 1);
			}
		}
		public void Error()
		{
			CompilationError = true;
		}
		public object Copy()
		{
			return this.MemberwiseClone();
		}
	}
}
