namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCASnowHorseHandler : LevelCAByWeatherCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASnowHorseHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

