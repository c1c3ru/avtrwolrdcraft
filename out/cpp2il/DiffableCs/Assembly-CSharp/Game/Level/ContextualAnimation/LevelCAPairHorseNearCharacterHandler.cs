namespace Game.Level.ContextualAnimation;

public class LevelCAPairHorseNearCharacterHandler : LevelCAPairAnimalNearCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAPairHorseNearCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual void PlayPetAnimation(LevelCAConfig config) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

