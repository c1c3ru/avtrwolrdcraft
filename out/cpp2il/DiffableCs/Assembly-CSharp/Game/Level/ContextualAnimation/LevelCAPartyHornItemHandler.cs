namespace Game.Level.ContextualAnimation;

public class LevelCAPartyHornItemHandler : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	private string _characterPartyHornSkinName; //Field offset: 0xB0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xB8
	[SerializeField]
	private string _soundNamePrefix; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC8

	public LevelCAPartyHornItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

