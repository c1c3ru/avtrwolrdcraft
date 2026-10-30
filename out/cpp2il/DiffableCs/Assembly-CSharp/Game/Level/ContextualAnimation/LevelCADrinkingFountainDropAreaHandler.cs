namespace Game.Level.ContextualAnimation;

public class LevelCADrinkingFountainDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private string _soundName; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCADrinkingFountainDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

