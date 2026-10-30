namespace Game.Level.ContextualAnimation;

public class LevelCAEmptyPoopBagItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private float _radius; //Field offset: 0x88
	private LevelCharacter _character; //Field offset: 0x90
	private LevelItem _collectedPoop; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAEmptyPoopBagItemHandler() { }

	[CompilerGenerated]
	private bool <CollectPoop>b__9_0(LevelItem x) { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	protected virtual void Awake() { }

	private bool CheckIfPoopNearby(out LevelItem poop) { }

	private void CollectPoop() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene obj) { }

}

