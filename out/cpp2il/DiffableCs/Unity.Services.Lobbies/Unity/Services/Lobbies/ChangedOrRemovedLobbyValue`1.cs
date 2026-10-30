namespace Unity.Services.Lobbies;

public struct ChangedOrRemovedLobbyValue
{
	public static readonly ChangedOrRemovedLobbyValue<T> RemoveThisValue; //Field offset: 0x0
	[CompilerGenerated]
	private readonly T <Value>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly LobbyValueChangeType <ChangeType>k__BackingField; //Field offset: 0x0

	public bool Added
	{
		 get { } //Length: 112
	}

	public bool Changed
	{
		 get { } //Length: 196
	}

	public LobbyValueChangeType ChangeType
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
	}

	public bool Removed
	{
		 get { } //Length: 112
	}

	public T Value
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
	}

	private static ChangedOrRemovedLobbyValue`1() { }

	public ChangedOrRemovedLobbyValue`1(T value, LobbyValueChangeType status) { }

	public bool get_Added() { }

	public bool get_Changed() { }

	[CompilerGenerated]
	[IsReadOnly]
	public LobbyValueChangeType get_ChangeType() { }

	public bool get_Removed() { }

	[CompilerGenerated]
	[IsReadOnly]
	public T get_Value() { }

}

