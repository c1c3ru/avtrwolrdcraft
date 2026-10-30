namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelEntity : MonoBehaviour, ILevelEntity
{
	private SortingGroup _sortingGroup; //Field offset: 0x20
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	private SortingElement _sortingElement; //Field offset: 0x30
	[CompilerGenerated]
	private readonly List<LevelAreaBase> <MyAreas>k__BackingField; //Field offset: 0x38

	public override List<LevelAreaBase> MyAreas
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public LevelEntity() { }

	private void Awake() { }

	[CompilerGenerated]
	public override List<LevelAreaBase> get_MyAreas() { }

	public override SortingElement GetSortingElement() { }

	public override int GetSortingOrder() { }

	public override Transform GetTransform() { }

}

