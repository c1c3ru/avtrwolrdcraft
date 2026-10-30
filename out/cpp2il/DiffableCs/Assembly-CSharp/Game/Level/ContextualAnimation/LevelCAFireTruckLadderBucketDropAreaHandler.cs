namespace Game.Level.ContextualAnimation;

public class LevelCAFireTruckLadderBucketDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private CShape _avatarCShape; //Field offset: 0x80
	public UnityEvent Event; //Field offset: 0x88
	private CShape _targetCShape; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAFireTruckLadderBucketDropAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUpAction(LevelItem levelItem) { }

	private void OnPostInitAction() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

