namespace Game.Level.ContextualAnimation;

public class LevelCAPairCharacterNearCharacterHandler : LevelCAPairHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAHandlerBase> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <OnAnimationBegin>b__3_0(LevelCAHandlerBase caHandler) { }

	}

	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0
	private string lastAnimation; //Field offset: 0xA8

	public LevelCAPairCharacterNearCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual CACategoryType GetCategoryType() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	public virtual void OnItemDetachedFromTarget(ICATarget target, LevelItem levelItem) { }

	private void PlayLoopAnimation(TrackEntry trackEntry) { }

	protected void PlayReactionAnimation(LevelCAConfig config) { }

}

