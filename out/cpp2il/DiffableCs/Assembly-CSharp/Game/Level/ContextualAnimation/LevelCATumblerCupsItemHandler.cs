namespace Game.Level.ContextualAnimation;

public class LevelCATumblerCupsItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private Transform _item; //Field offset: 0x88
	[SerializeField]
	private float _xOffset; //Field offset: 0x90
	private int _tweenIDBegin; //Field offset: 0x94
	private int _tweenIDEnd; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCATumblerCupsItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationInterrupt(TrackEntry trackEntry) { }

}

