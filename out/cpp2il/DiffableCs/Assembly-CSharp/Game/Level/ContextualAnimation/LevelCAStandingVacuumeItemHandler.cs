namespace Game.Level.ContextualAnimation;

public class LevelCAStandingVacuumeItemHandler : LevelCAHandVacuumeItemHandler
{
	[SerializeField]
	private Sprite _holdingSprite; //Field offset: 0xA0
	[SerializeField]
	private Sprite _defaultSprite; //Field offset: 0xA8
	[SerializeField]
	private ParticleSystem _heldParticlSystem; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAStandingVacuumeItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected virtual void ShowParticles() { }

	protected virtual void StopParticles() { }

}

