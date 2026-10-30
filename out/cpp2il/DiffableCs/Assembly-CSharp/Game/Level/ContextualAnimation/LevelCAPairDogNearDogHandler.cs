namespace Game.Level.ContextualAnimation;

public class LevelCAPairDogNearDogHandler : LevelCAPairAnimalNearDogHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAPairDogNearDogHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual CACategoryType GetCategoryType() { }

	public virtual string GetFolderName() { }

	protected virtual void PlayPetAnimation(LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

