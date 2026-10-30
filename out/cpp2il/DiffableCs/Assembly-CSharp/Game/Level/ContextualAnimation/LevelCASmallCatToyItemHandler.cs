namespace Game.Level.ContextualAnimation;

public class LevelCASmallCatToyItemHandler : LevelCAItemHandlerBase
{
	private BoneFollower _boneFollower; //Field offset: 0x88
	private Vector2 _mouthOffset; //Field offset: 0x90
	private Vector3 _mouthScale; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCASmallCatToyItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

