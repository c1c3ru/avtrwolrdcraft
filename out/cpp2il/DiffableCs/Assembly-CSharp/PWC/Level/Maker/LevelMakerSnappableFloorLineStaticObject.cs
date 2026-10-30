namespace PWC.Level.Maker;

public class LevelMakerSnappableFloorLineStaticObject : MonoBehaviour, ILevelMakerSnappableFloorLineObject
{
	[SerializeReference]
	private SortingGroup _sortingGroup; //Field offset: 0x20
	[SerializeReference]
	private LevelAreaBase _area; //Field offset: 0x28

	public LevelMakerSnappableFloorLineStaticObject() { }

	private void Awake() { }

	public override Bounds GetBounds() { }

	public override CShape GetWallCShape() { }

	public override GameShape GetWallGameShape() { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	public override void SetContentSortingOrder(int sortingOrder) { }

}

