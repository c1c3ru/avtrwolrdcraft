namespace Game.Level.ContextualAnimation;

public class LevelCAPairSmallPetNearCharacterHandler : LevelCAPairAnimalNearCharacterHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAPairSmallPetNearCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private void OnAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void PlayPetAnimation(LevelCAConfig config) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

