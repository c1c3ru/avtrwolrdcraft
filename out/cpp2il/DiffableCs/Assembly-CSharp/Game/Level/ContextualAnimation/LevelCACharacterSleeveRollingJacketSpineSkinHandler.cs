namespace Game.Level.ContextualAnimation;

public class LevelCACharacterSleeveRollingJacketSpineSkinHandler : LevelCASpecialClothingSpineSkinHandler
{
	private readonly List<LevelCAConfig> _firstConfigGroup; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _secondConfigGroup; //Field offset: 0xC0

	public LevelCACharacterSleeveRollingJacketSpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual int GetSpecialCategoryType() { }

	protected virtual String[] GetSwitchableTextures() { }

	protected virtual string GetTextureSurffix() { }

	protected virtual void TakeOffClothing(ICATarget avatar) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

