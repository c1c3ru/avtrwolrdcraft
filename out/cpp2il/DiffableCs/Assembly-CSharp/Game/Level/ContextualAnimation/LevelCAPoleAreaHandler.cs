namespace Game.Level.ContextualAnimation;

public class LevelCAPoleAreaHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x80
	[SerializeField]
	private LevelCrossAllLevelDropArea _levelCrossAllLevelDropArea; //Field offset: 0x88
	private readonly Dictionary<AvatarSizeType, Single> _xPositionByAvatarSize; //Field offset: 0x90
	private readonly Dictionary<AvatarSizeType, Int32> _sortingByAvatarSize; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAPoleAreaHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected virtual void OnDestroy() { }

	private void OnPreSaveProgress(Scene scene) { }

}

