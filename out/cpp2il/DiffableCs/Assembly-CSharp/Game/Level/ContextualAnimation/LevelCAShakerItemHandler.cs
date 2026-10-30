namespace Game.Level.ContextualAnimation;

public class LevelCAShakerItemHandler : LevelCAItemHandlerBase
{
	private const string ADDING_SALT_ANIMATION_NAME = "Adding_Salt"; //Field offset: 0x0
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0x88
	private int _particleOnTweenID; //Field offset: 0x90
	private int _particleOffTweenID; //Field offset: 0x94
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAShakerItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__6_0() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__6_1() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void ToggleParticles(bool state) { }

}

