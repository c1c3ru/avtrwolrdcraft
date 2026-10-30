namespace Game.Level.ContextualAnimation;

[DisallowMultipleComponent]
public class LevelCASnowCharacterHandler : LevelCAByWeatherCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASnowCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private PDPrefab GetPrefab(string name, Vector2 position) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

