namespace Game.Level.ContextualAnimation;

public class LevelCAScissorsItemHandler : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	private string _skinName; //Field offset: 0xB0
	[SerializeField]
	private string _soundName; //Field offset: 0xB8
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC8

	public LevelCAScissorsItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

