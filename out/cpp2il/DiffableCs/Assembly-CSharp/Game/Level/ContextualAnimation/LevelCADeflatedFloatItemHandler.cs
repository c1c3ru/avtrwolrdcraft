namespace Game.Level.ContextualAnimation;

public class LevelCADeflatedFloatItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCADeflatedFloatItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

