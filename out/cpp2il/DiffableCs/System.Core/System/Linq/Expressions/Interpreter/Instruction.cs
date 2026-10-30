namespace System.Linq.Expressions.Interpreter;

internal abstract class Instruction
{

	public override int ConsumedContinuations
	{
		 get { } //Length: 8
	}

	public override int ConsumedStack
	{
		 get { } //Length: 8
	}

	public int ContinuationsBalance
	{
		 get { } //Length: 60
	}

	public abstract string InstructionName
	{
		 get { } //Length: 0
	}

	public override int ProducedContinuations
	{
		 get { } //Length: 8
	}

	public override int ProducedStack
	{
		 get { } //Length: 8
	}

	public int StackBalance
	{
		 get { } //Length: 60
	}

	protected Instruction() { }

	public override int get_ConsumedContinuations() { }

	public override int get_ConsumedStack() { }

	public int get_ContinuationsBalance() { }

	public abstract string get_InstructionName() { }

	public override int get_ProducedContinuations() { }

	public override int get_ProducedStack() { }

	public int get_StackBalance() { }

	protected static void NullCheck(object o) { }

	public abstract int Run(InterpretedFrame frame) { }

	public override string ToDebugString(int instructionIndex, object cookie, Func<Int32, Int32> labelIndexer, IReadOnlyList<Object> objects) { }

	public virtual string ToString() { }

}

