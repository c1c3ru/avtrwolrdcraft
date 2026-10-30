namespace Game.Level.ContextualAnimation;

public class LevelCAHoldingSkateboardItemHandler : LevelCAItemOnBoneHandlerBase
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x98
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA0
	[SerializeField]
	private GameObject _holdPoint; //Field offset: 0xA8
	private LevelCharacter _character; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAHoldingSkateboardItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

