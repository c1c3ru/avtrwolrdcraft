namespace PWC.PersistentData;

[RequireComponent(typeof(PDPrefab))]
public class PDPrefabPack : MonoBehaviour, IPDPack
{
	private PDPrefab _pdPrefab; //Field offset: 0x20
	[CompilerGenerated]
	private List<PDPrefab> <ChildPrefabs>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private List<Transform> <ImmediateChildren>k__BackingField; //Field offset: 0x30

	public private List<PDPrefab> ChildPrefabs
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private List<Transform> ImmediateChildren
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public PDPrefabPack() { }

	private void Awake() { }

	[CompilerGenerated]
	public List<PDPrefab> get_ChildPrefabs() { }

	[CompilerGenerated]
	public List<Transform> get_ImmediateChildren() { }

	private void OnDestroy() { }

	private void OnSpawn(bool multiplayer_ensureGuids) { }

	[CompilerGenerated]
	private void set_ChildPrefabs(List<PDPrefab> value) { }

	[CompilerGenerated]
	private void set_ImmediateChildren(List<Transform> value) { }

}

