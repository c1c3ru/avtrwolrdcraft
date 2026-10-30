namespace Game.Level.ContextualAnimation;

public class LevelCAPoolNoodleItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private LevelCharacter _currentCharacter; //Field offset: 0x90
	private string _currentSoundName; //Field offset: 0x98

	public LevelCAPoolNoodleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

	private void OnPlayStartSound(TrackEntry trackEntry) { }

}

