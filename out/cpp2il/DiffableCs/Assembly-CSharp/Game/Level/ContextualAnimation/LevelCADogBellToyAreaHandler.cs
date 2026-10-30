namespace Game.Level.ContextualAnimation;

public class LevelCADogBellToyAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private PDPrefabReference _dogTreatToSpawn; //Field offset: 0x80
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x88
	[SerializeField]
	private string _soundName; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCADogBellToyAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

