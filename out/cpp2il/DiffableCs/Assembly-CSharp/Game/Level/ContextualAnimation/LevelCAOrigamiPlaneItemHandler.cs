namespace Game.Level.ContextualAnimation;

public class LevelCAOrigamiPlaneItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelCharacter character; //Field offset: 0x10
		public PDPrefab instance; //Field offset: 0x18
		public LevelItem levelItem; //Field offset: 0x20

		public <>c__DisplayClass8_0() { }

		internal void <OnAnimationEvent>b__0() { }

		internal void <OnAnimationEvent>b__1() { }

	}

	private bool _isFail; //Field offset: 0x88
	private LevelItem _detachedItem; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAOrigamiPlaneItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnBeginDragDetachedItem(DragDropItemBase dragDropItem, PointerEventData pointerEventData) { }

	private void OnChildDropAreaItemEndDropDetachedItem(LevelDropArea dropArea, LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

}

