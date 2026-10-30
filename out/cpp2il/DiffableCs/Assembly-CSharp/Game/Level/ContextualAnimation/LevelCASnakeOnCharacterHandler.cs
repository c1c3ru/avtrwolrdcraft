namespace Game.Level.ContextualAnimation;

public class LevelCASnakeOnCharacterHandler : LevelCAPetOnCharacterHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelAnimal pet; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal void <OnAnimationEvent>b__0(TrackEntry x) { }

	}

	private const string HOLDING_PET_ANIMATION_NAME = "General/Sitting_Idle"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCASnakeOnCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

