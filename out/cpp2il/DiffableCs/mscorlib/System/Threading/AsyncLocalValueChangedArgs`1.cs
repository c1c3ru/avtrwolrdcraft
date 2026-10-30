namespace System.Threading;

[IsReadOnly]
public struct AsyncLocalValueChangedArgs
{
	[CompilerGenerated]
	private readonly T <PreviousValue>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly T <CurrentValue>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly bool <ThreadContextChanged>k__BackingField; //Field offset: 0x0

	public T CurrentValue
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal AsyncLocalValueChangedArgs`1(T previousValue, T currentValue, bool contextChanged) { }

	[CompilerGenerated]
	public T get_CurrentValue() { }

}

