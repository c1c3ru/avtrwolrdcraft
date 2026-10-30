namespace System.Linq.Expressions.Interpreter;

internal abstract class NegateInstruction : Instruction
{
	private sealed class NegateDouble : NegateInstruction
	{

		public NegateDouble() { }

		public virtual int Run(InterpretedFrame frame) { }

	}

	private sealed class NegateInt16 : NegateInstruction
	{

		public NegateInt16() { }

		public virtual int Run(InterpretedFrame frame) { }

	}

	private sealed class NegateInt32 : NegateInstruction
	{

		public NegateInt32() { }

		public virtual int Run(InterpretedFrame frame) { }

	}

	private sealed class NegateInt64 : NegateInstruction
	{

		public NegateInt64() { }

		public virtual int Run(InterpretedFrame frame) { }

	}

	private sealed class NegateSingle : NegateInstruction
	{

		public NegateSingle() { }

		public virtual int Run(InterpretedFrame frame) { }

	}

	private static Instruction s_Int16; //Field offset: 0x0
	private static Instruction s_Int32; //Field offset: 0x8
	private static Instruction s_Int64; //Field offset: 0x10
	private static Instruction s_Single; //Field offset: 0x18
	private static Instruction s_Double; //Field offset: 0x20

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

	private NegateInstruction() { }

	public static Instruction Create(Type type) { }

	public virtual int get_ConsumedStack() { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedStack() { }

}

