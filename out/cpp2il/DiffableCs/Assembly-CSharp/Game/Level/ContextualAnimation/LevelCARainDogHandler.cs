namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCARainDogHandler : LevelCAByWeatherCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCARainDogHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

