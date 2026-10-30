namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCARainCharacterHandler : LevelCAByWeatherCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCARainCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

