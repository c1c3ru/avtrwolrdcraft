namespace Game.Level.ContextualAnimation;

public class LevelCABeachPaddleItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private Sprite _normal; //Field offset: 0x88
	[SerializeField]
	private Sprite _held; //Field offset: 0x90
	[SerializeField]
	private GameObject _ballPrefab; //Field offset: 0x98
	[SerializeField]
	private Sprite[] _balls; //Field offset: 0xA0
	private GameObject _ball; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCABeachPaddleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

