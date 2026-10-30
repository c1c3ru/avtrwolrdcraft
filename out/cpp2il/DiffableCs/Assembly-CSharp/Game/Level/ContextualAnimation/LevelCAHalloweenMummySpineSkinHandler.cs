namespace Game.Level.ContextualAnimation;

public class LevelCAHalloweenMummySpineSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAHalloweenMummySpineSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

