namespace System.Linq.Expressions.Interpreter;

internal class BranchInstruction : OffsetInstruction
{
	private static Instruction[][][] s_caches; //Field offset: 0x0
	internal readonly bool _hasResult; //Field offset: 0x14
	internal readonly bool _hasValue; //Field offset: 0x15

	public virtual Instruction[] Cache
	{
		 get { } //Length: 600
	}

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

	internal BranchInstruction() { }

	public BranchInstruction(bool hasResult, bool hasValue) { }

	public virtual Instruction[] get_Cache() { }

	public virtual int get_ConsumedStack() { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

	public virtual int Run(InterpretedFrame frame) { }

}

