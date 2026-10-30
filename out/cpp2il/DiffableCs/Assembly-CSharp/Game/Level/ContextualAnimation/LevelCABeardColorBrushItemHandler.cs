namespace Game.Level.ContextualAnimation;

public class LevelCABeardColorBrushItemHandler : LevelCAItemHandlerBase
{
	private LevelBeardColorBrush _beardColorBrush; //Field offset: 0x88
	private readonly HashSet<LevelCharacter> _affectingCharacters; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCABeardColorBrushItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

