namespace Game.Level.ContextualAnimation;

public class LevelCAToiletSitAreaHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAToiletSitAreaHandler() { }

	protected virtual void Awake() { }

	private bool CanOpenDoor() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	protected virtual void OnDestroy() { }

}

