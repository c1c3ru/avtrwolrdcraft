namespace Game.Level.ContextualAnimation;

public class LevelCAPetPoopHandler : LevelCAHandlerBase
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x80
	[SerializeField]
	private Transform _poopPoistion; //Field offset: 0x88
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAPetPoopHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

