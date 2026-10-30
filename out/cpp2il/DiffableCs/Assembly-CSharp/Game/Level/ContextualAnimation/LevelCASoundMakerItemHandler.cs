namespace Game.Level.ContextualAnimation;

public class LevelCASoundMakerItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelToggleableMultipleAudio _soundMaker; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCASoundMakerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

