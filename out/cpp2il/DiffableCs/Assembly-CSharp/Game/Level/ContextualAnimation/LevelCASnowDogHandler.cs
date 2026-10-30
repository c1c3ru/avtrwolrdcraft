namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCASnowDogHandler : LevelCAByWeatherCharacterHandlerBase
{
	private int _soundIndex; //Field offset: 0x84
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASnowDogHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

