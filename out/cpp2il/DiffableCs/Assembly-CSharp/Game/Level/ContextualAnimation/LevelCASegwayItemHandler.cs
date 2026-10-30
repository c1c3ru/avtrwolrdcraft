namespace Game.Level.ContextualAnimation;

public class LevelCASegwayItemHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private GameObject _boneFollowerObject; //Field offset: 0x80
	[SerializeField]
	private GameObject _staticSegway; //Field offset: 0x88
	[SerializeField]
	private GameObject _staticSegwayFront; //Field offset: 0x90
	[SerializeField]
	private Sprite _thumbSprite; //Field offset: 0x98
	private BoneFollower _boneFollower; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCASegwayItemHandler() { }

	private void DestroyBoneFollower() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

