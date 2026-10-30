namespace System.Linq.Expressions.Interpreter;

internal sealed class DupInstruction : Instruction
{
	internal static readonly DupInstruction Instance; //Field offset: 0x0

	public virtual string InstructionName
	{
		 get { } //Length: 64
	}

	public virtual int ProducedStack
	{
		 get { } //Length: 8
	}

	private static DupInstruction() { }

	private DupInstruction() { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

	public virtual int Run(InterpretedFrame frame) { }

}

