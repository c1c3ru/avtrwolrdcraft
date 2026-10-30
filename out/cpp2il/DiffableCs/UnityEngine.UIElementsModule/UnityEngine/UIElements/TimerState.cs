namespace UnityEngine.UIElements;

public struct TimerState : IEquatable<TimerState>
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private long <start>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private long <now>k__BackingField; //Field offset: 0x8

	public long deltaTime
	{
		 get { } //Length: 12
	}

	public long now
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public long start
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public virtual bool Equals(object obj) { }

	public override bool Equals(TimerState other) { }

	public long get_deltaTime() { }

	[CompilerGenerated]
	[IsReadOnly]
	public long get_now() { }

	[CompilerGenerated]
	[IsReadOnly]
	public long get_start() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	public void set_now(long value) { }

	[CompilerGenerated]
	public void set_start(long value) { }

}

