namespace Game.Level.ContextualAnimation;

public class LevelCAValentinesRoseItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelValentinesRoseItemHandler _valentinesRoseItemHandler; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90
	private readonly List<LevelCAConfig> _localConfigs; //Field offset: 0x98
	private ICATarget _icaTarget; //Field offset: 0xA0

	public LevelCAValentinesRoseItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationEnd>b__10_0(TrackEntry _) { }

	[CompilerGenerated]
	private void <OnAnimationEnd>b__10_1(TrackEntry _) { }

	[CompilerGenerated]
	private void <OnAnimationEnd>b__10_2(TrackEntry _) { }

	[CompilerGenerated]
	private void <OnAnimationEnd>b__10_3(TrackEntry _) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEnd() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void OnEventAction(TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool ShouldReturnToIdleAnimationAtEndOfAnimation() { }

}

