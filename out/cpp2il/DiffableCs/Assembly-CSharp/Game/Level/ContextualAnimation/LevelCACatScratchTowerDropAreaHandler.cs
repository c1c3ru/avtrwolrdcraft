namespace Game.Level.ContextualAnimation;

public class LevelCACatScratchTowerDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private Transform _towerScratchCatPoint; //Field offset: 0x80
	private Vector2 _catBeforeScratchPosition; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCACatScratchTowerDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

