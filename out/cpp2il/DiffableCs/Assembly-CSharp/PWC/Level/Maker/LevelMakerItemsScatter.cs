namespace PWC.Level.Maker;

public class LevelMakerItemsScatter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<UnpackedItem, Transform> <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Transform <ScatterItems>b__10_0(UnpackedItem x) { }

	}

	internal class UnpackedItem
	{
		public int tweenId; //Field offset: 0x10
		public Vector2 destination; //Field offset: 0x14
		public Transform instance; //Field offset: 0x20

		public UnpackedItem() { }

	}

	private PDTextBulkData _pdTextBulkData; //Field offset: 0x20
	private Vector2 _startingPoisiton; //Field offset: 0x28
	private UnpackedItem[] _unpackedItems; //Field offset: 0x30
	private readonly Dictionary<PDPrefab, PDPrefab[]> _prefabChildrenCache; //Field offset: 0x38
	private readonly Dictionary<PDPrefab, PDSceneObject> _sceneObjectCache; //Field offset: 0x40

	public LevelMakerItemsScatter() { }

	private void Awake() { }

	private void LoadItems(bool useTween = true) { }

	private void OnDestroy() { }

	private void OnPreSaveProgress(Scene obj) { }

	public List<Transform> ScatterItems(bool useTween = true) { }

	public void SetPDTextBulkData(PDTextBulkData bulkData) { }

	public void TrackItems() { }

}

