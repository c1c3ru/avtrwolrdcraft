namespace PWC.InteractionHistory;

public class Data : ISerializationCallbackReceiver
{
	public const int BUILD_NUMBER_WHEN_RELEASE = 14; //Field offset: 0x0
	public int gameBuildNumber; //Field offset: 0x10
	public bool shouldShowNewIconInHome; //Field offset: 0x14
	public int lastHomeNewIconBuildingsCount; //Field offset: 0x18
	public List<Int32> interactedBuildingIds; //Field offset: 0x20
	public List<Int32> buildingIdsAtFirstOpen; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsDirty>k__BackingField; //Field offset: 0x30
	private HashSet<Int32> _hashedInteractedBuildingIds; //Field offset: 0x38
	private HashSet<Int32> _hashedbuildingIdsAtFirstOpen; //Field offset: 0x40

	public bool IsDirty
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public Data() { }

	private void EnsureHashedData() { }

	[CompilerGenerated]
	public bool get_IsDirty() { }

	public bool IsNewBuilding(int buildingId) { }

	public void MarkBuildingAsInteracted(int buildingId) { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	[CompilerGenerated]
	public void set_IsDirty(bool value) { }

}

