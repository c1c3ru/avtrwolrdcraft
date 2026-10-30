namespace Game.Store;

public class StoreState : ISerializationCallbackReceiver
{
	public List<String> claimedItems; //Field offset: 0x10
	[CompilerGenerated]
	private HashSet<String> <HashedClaimedItems>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private bool <IsDirty>k__BackingField; //Field offset: 0x20

	public private HashSet<String> HashedClaimedItems
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool IsDirty
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public StoreState() { }

	[CompilerGenerated]
	public HashSet<String> get_HashedClaimedItems() { }

	[CompilerGenerated]
	public bool get_IsDirty() { }

	public void LogState() { }

	[CompilerGenerated]
	private void set_HashedClaimedItems(HashSet<String> value) { }

	[CompilerGenerated]
	public void set_IsDirty(bool value) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

