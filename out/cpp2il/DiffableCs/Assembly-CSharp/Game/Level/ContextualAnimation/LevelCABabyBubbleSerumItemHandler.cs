namespace Game.Level.ContextualAnimation;

public class LevelCABabyBubbleSerumItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelParticleSystemOnDragItemHandler _particleSystemOnDragItemHandler; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCABabyBubbleSerumItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__4_0() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

