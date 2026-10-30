namespace PWC.Level;

[AddComponentMenu(null)]
[DisallowMultipleComponent]
public class LevelStationaryItem : StationaryInteractableItem, ILevelEntity
{
	protected SortingGroup _sortingGroup; //Field offset: 0x40
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x48
	private SortingElement _sortingElement; //Field offset: 0x50
	[CompilerGenerated]
	private readonly List<LevelAreaBase> <MyAreas>k__BackingField; //Field offset: 0x58

	public override List<LevelAreaBase> MyAreas
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public LevelStationaryItem() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public override List<LevelAreaBase> get_MyAreas() { }

	public override SortingElement GetSortingElement() { }

	public override int GetSortingOrder() { }

	public override Transform GetTransform() { }

}

