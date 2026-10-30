namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerToyBubbleGunItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private ParticleSystem _bubblesParticles; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAToddlerToyBubbleGunItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

