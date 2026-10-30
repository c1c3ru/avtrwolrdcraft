namespace System.Linq.Expressions.Interpreter;

internal sealed class EnterTryCatchFinallyInstruction : IndexedBranchInstruction
{
	private readonly bool _hasFinally; //Field offset: 0x14
	private TryCatchFinallyHandler _tryHandler; //Field offset: 0x18

	internal TryCatchFinallyHandler Handler
	{
		internal get { } //Length: 8
	}

	public virtual string InstructionName
	{
		 get { } //Length: 108
	}

	public virtual int ProducedContinuations
	{
		 get { } //Length: 8
	}

	private EnterTryCatchFinallyInstruction(int targetIndex, bool hasFinally) { }

	internal static EnterTryCatchFinallyInstruction CreateTryCatch() { }

	internal static EnterTryCatchFinallyInstruction CreateTryFinally(int labelIndex) { }

	internal TryCatchFinallyHandler get_Handler() { }

	public virtual string get_InstructionName() { }

	public virtual int get_ProducedContinuations() { }

	public virtual int Run(InterpretedFrame frame) { }

	internal void SetTryHandler(TryCatchFinallyHandler tryHandler) { }

	public virtual string ToString() { }

}

