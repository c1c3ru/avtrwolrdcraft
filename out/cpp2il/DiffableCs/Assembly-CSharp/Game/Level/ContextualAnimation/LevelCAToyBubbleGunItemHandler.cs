namespace Game.Level.ContextualAnimation;

public class LevelCAToyBubbleGunItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private ParticleSystem _bubblesParticles; //Field offset: 0x88
	[SerializeField]
	private LevelItemInCharacterBoneTransformOverride _bone; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAToyBubbleGunItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

