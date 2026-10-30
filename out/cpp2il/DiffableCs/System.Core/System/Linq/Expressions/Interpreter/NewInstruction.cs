namespace System.Linq.Expressions.Interpreter;

internal class NewInstruction : Instruction
{
	protected readonly ConstructorInfo _constructor; //Field offset: 0x10
	protected readonly int _argumentCount; //Field offset: 0x18

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

	public NewInstruction(ConstructorInfo constructor, int argumentCount) { }

	public virtual int get_ConsumedStack() { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

	protected Object[] GetArgs(InterpretedFrame frame, int first) { }

	public virtual int Run(InterpretedFrame frame) { }

	public virtual string ToString() { }

}

