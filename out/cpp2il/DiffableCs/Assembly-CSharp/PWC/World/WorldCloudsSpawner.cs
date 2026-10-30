namespace PWC.World;

public class WorldCloudsSpawner : MonoBehaviour, IWorldCloudSpawner
{
	[CompilerGenerated]
	private int <CloudSortingOrder>k__BackingField; //Field offset: 0x20
	[SerializeField]
	private Transform _endPoint; //Field offset: 0x28
	[SerializeField]
	private float _maxYPosition; //Field offset: 0x30
	[SerializeField]
	private float _minYPosition; //Field offset: 0x34
	[SerializeField]
	private List<WorldCloud> _initialClouds; //Field offset: 0x38
	[FormerlySerializedAs("_cloudSprites")]
	[SerializeField]
	private List<Sprite> _clearCloudSprites; //Field offset: 0x40
	[SerializeField]
	private List<Sprite> _rainCloudsSprites; //Field offset: 0x48
	[SerializeField]
	private List<Sprite> _heavyRainCloudsSprites; //Field offset: 0x50
	[SerializeField]
	private int _sortingOrder; //Field offset: 0x58
	private GameObject _cloudPrefab; //Field offset: 0x60

	public private int CloudSortingOrder
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public WorldCloudsSpawner() { }

	[CompilerGenerated]
	private void <Init>b__13_0(WorldCloud cloud) { }

	[CompilerGenerated]
	public int get_CloudSortingOrder() { }

	public void Init() { }

	public override void OnCloudDestroy(WorldCloud cloud) { }

	private void OnDrawGizmos() { }

	[CompilerGenerated]
	private void set_CloudSortingOrder(int value) { }

	private void SetRandomSpriteForCloud(WorldCloud cloud) { }

	private void SpawnCloud() { }

}

