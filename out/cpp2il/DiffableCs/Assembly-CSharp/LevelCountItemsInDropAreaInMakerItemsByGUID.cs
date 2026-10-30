//Type is in global namespace

public class LevelCountItemsInDropAreaInMakerItemsByGUID : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private static List<LevelCountItemsInDropAreaInMakerItemsByGUID> _instancesInScene; //Field offset: 0x0
	[SerializeField]
	private LevelMakerItem _makerItem; //Field offset: 0x20
	[SerializeField]
	private int _numberOfItemsToCount; //Field offset: 0x28
	[SerializeField]
	private LevelSingleItemDropArea _singleItemDropArea; //Field offset: 0x30
	[SerializeField]
	private List<PDPrefabReference> _pDPrefabReferences; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onCoundReached; //Field offset: 0x40

	public LevelCountItemsInDropAreaInMakerItemsByGUID() { }

	private void AddToList() { }

	private void Awake() { }

	public void CountItemsInDropAreas() { }

	public LevelSingleItemDropArea GetSingleItemDropArea() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	private void RemoveFromList() { }

}

