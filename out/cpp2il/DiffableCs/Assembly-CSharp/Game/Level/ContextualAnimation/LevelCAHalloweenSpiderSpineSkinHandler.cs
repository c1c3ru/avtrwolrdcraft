namespace Game.Level.ContextualAnimation;

public class LevelCAHalloweenSpiderSpineSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	private const string _PDPrefabName = "C_Spooky_Banner_03_P6"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAHalloweenSpiderSpineSkinHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	private void TakeOfBackItem(LevelCharacter character) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

