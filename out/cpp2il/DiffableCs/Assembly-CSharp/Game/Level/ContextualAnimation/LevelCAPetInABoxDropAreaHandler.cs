namespace Game.Level.ContextualAnimation;

public class LevelCAPetInABoxDropAreaHandler : LevelCADropAreaHandlerBase
{
	private AnimalType _currentAnimalType; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAPetInABoxDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

}

