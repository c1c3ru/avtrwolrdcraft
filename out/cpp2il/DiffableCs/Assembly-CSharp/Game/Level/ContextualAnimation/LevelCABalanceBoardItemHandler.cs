namespace Game.Level.ContextualAnimation;

public class LevelCABalanceBoardItemHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x80
	[SerializeField]
	private GameObject _boneFollowerObject; //Field offset: 0x88
	[SerializeField]
	private GameObject _staticSkateboard; //Field offset: 0x90
	private List<LevelCAConfig> _allCAConfings; //Field offset: 0x98
	private LevelCharacter _currentCharacter; //Field offset: 0xA0
	private BoneFollower _boneFollower; //Field offset: 0xA8
	private LevelDropArea _dropArea; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8
	private bool _isBoneFollowerStarted; //Field offset: 0xC0

	public LevelCABalanceBoardItemHandler() { }

	protected virtual void Awake() { }

	private void DestroyBoneFollower() { }

	public void EndBoneFollower() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected virtual void OnDestroy() { }

	private void OnItemPickUp(LevelItem _) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public void StartBoneFollower() { }

}

