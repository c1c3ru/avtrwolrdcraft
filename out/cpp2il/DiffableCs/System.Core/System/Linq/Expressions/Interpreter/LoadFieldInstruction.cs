namespace System.Linq.Expressions.Interpreter;

internal sealed class LoadFieldInstruction : FieldInstruction
{

	public virtual int ConsumedStack
	{
		 get { } //Length: 8
	}

	public virtual string InstructionName
	{
		 get { } //Length: 64
	}

	public virtual int ProducedStack
	{
		 get { } //Length: 8
	}

	public LoadFieldInstruction(FieldInfo field) { }

	public virtual int get_ConsumedStack() { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

	public virtual int Run(InterpretedFrame frame) { }

}

