using System;
using System.Collections.Generic;

namespace Codeblock.Model
{
	public class LogicBlock : Node
	{
		public CodeBlock CodeBlock;
		public List<LogicObject> AreaLogicObjects;
		public LogicBlock(CodeBlock codeBlock) : base()
		{
			CodeBlock = codeBlock;
			AreaLogicObjects = new List<LogicObject>();
		}
		public override void Compilation(CodeBlock CurrentCodeBlock)
		{
			foreach(LogicObject CurrentLogicObject in AreaLogicObjects)
            {
				CurrentLogicObject.Compilation(CurrentCodeBlock);

				if (CurrentLogicObject.Boolean == "true") break;
				if (CurrentLogicObject.Commands.CompilationError)
                {
					CurrentCodeBlock.Error();
					break;
				}
            }
		}
		public void AddElseIf(LogicObject logicObject)
		{
			AreaLogicObjects.Add(logicObject);
		}

		public void AddElse(LogicObject logicObject)
		{
			AreaLogicObjects.Add(logicObject);
		}
	}
}