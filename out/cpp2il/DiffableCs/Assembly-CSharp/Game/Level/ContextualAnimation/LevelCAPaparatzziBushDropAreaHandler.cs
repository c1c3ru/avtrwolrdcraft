namespace Game.Level.ContextualAnimation;

public class LevelCAPaparatzziBushDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private SkeletonAnimation _bushSkeletonAnimation; //Field offset: 0x80
	[SerializeField]
	private LevelDoor _bushDoor; //Field offset: 0x88
	[SerializeField]
	private GameSoundPlayer _bushSoundPlayer; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAPaparatzziBushDropAreaHandler() { }

	private void BushAnimationEvent(TrackEntry trackEntry, Event e) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

