namespace Unity.Services.Lobbies;

public struct ChangedLobbyValue
{
	[CompilerGenerated]
	private readonly T <Value>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly bool <Changed>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private bool <Added>k__BackingField; //Field offset: 0x0

	public internal bool Added
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 12
	}

	public bool Changed
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
	}

	public T Value
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
	}

	public ChangedLobbyValue`1(T value) { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_Added() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_Changed() { }

	[CompilerGenerated]
	[IsReadOnly]
	public T get_Value() { }

	[CompilerGenerated]
	internal void set_Added(bool value) { }

}

