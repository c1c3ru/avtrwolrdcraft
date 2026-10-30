namespace Game.Level.ContextualAnimation;

public class LevelCAFountainDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelDropArea _fountainDropArea; //Field offset: 0x80
	private LevelItem _coin; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAFountainDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void ThrowCoin() { }

}

