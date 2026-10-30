namespace Game.Level.ContextualAnimation;

public class LevelCACastMoldItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	protected PDPrefabReference[] _casts; //Field offset: 0x88
	[SerializeField]
	protected LevelSpawner _spawner; //Field offset: 0x90
	[SerializeField]
	private string _craftingSoundName; //Field offset: 0x98
	private int _animIndex; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCACastMoldItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	protected bool TrySpawnItem(LevelCharacter character, ICATarget target) { }

}

