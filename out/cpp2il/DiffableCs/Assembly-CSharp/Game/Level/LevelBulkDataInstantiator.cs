namespace Game.Level;

public class LevelBulkDataInstantiator : MonoBehaviour, IHasPDTextBulkData, IPDPack
{
	[SerializeField]
	private Transform _parent; //Field offset: 0x20
	[SerializeField]
	private PDTextBulkData _bulkData; //Field offset: 0x28
	[SerializeField]
	private bool _ignoreParentPosition; //Field offset: 0x30
	[SerializeField]
	private bool _isForceNotUsingItemTracker; //Field offset: 0x31
	private LevelItem _packItem; //Field offset: 0x38
	private bool _isSpawned; //Field offset: 0x40
	private List<Transform> _instances; //Field offset: 0x48

	public bool IsSpawned
	{
		 get { } //Length: 8
	}

	public LevelBulkDataInstantiator() { }

	private void Awake() { }

	public bool get_IsSpawned() { }

	public List<Transform> GetInstances() { }

	public LevelItem GetPackParent() { }

	public override PDTextBulkData GetPDTextBulkData() { }

	protected override bool IsIgnoringItemTracker() { }

	public void Spawn() { }

	private void SpawnScatter() { }

}

