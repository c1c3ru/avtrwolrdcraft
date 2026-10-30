namespace Game.Level.ContextualAnimation;

public class LevelCASuitcaseItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private GameObject _held; //Field offset: 0x88
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98
	private LevelCharacter _character; //Field offset: 0xA0
	private bool _isClicked; //Field offset: 0xA8

	public LevelCASuitcaseItemHandler() { }

	[CompilerGenerated]
	private void <OnRemovedFromTarget>b__9_0() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSilent() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	private void OnClickItem(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

