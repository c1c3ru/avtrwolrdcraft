namespace Game.Level.ContextualAnimation;

public class LevelCADogBagRemovalOnlySpineSkinHander : LevelCASpineSkinHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCADogBagRemovalOnlySpineSkinHander() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOfHat(LevelDog dog) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

