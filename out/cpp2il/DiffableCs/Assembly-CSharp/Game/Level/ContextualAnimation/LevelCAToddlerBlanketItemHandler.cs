namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerBlanketItemHandler : LevelCAItemHandlerBase
{
	private bool _isSwitchHands; //Field offset: 0x88
	private Vector3 _lastHandPosition; //Field offset: 0x8C
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98
	private LevelToddler _toddler; //Field offset: 0xA0

	public LevelCAToddlerBlanketItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

}

