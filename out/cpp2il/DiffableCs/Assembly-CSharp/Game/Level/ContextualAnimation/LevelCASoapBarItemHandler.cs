namespace Game.Level.ContextualAnimation;

public class LevelCASoapBarItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	protected LevelMakeupDataItemHandler _makeupDataItemHandler; //Field offset: 0x88
	[SerializeField]
	private string _AddedSkinSound; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCASoapBarItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

