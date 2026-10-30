namespace System.Linq.Expressions.Interpreter;

internal sealed class LoadObjectInstruction : Instruction
{
	private readonly object _value; //Field offset: 0x10

	public virtual string InstructionName
	{
		 get { } //Length: 64
	}

	public virtual int ProducedStack
	{
		 get { } //Length: 8
	}

	internal LoadObjectInstruction(object value) { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

	public virtual int Run(InterpretedFrame frame) { }

	public virtual string ToString() { }

}

