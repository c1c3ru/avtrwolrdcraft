namespace System.Linq.Expressions.Interpreter;

internal sealed class LoadLocalFromClosureBoxedInstruction : LocalAccessInstruction
{

	public virtual string InstructionName
	{
		 get { } //Length: 64
	}

	public virtual int ProducedStack
	{
		 get { } //Length: 8
	}

	internal LoadLocalFromClosureBoxedInstruction(int index) { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

	public virtual int Run(InterpretedFrame frame) { }

}

