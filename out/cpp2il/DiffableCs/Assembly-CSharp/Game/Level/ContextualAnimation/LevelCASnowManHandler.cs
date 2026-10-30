namespace Game.Level.ContextualAnimation;

public class LevelCASnowManHandler : LevelCAHandlerBase
{
	private const string GOOF_AROUND_ANIMATION_NAME = "Goof_Around"; //Field offset: 0x0
	private const string DANCE_ANIMATION_NAME = "Dance"; //Field offset: 0x0
	private const string BOW_ANIMATION_NAME = "Take_A_Bow"; //Field offset: 0x0
	private const string WAVE_ANIMATION_NAME = "Wave_Hello"; //Field offset: 0x0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASnowManHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

