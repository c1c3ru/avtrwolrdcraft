namespace Game.Level.ContextualAnimation;

public class LevelCAFurnitureConstructionDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	protected LevelItem _levelItem; //Field offset: 0x80
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x88
	[SerializeField]
	private bool _isLastPhase; //Field offset: 0x90
	[SerializeField]
	private PDPrefabReference _boxedFurniturePrefabReference; //Field offset: 0x98
	[SerializeField]
	private UnityEvent _onConstructionCompletedEvent; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAFurnitureConstructionDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

	protected bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

