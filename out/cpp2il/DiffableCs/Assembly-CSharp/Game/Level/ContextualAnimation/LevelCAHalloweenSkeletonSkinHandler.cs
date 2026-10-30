namespace Game.Level.ContextualAnimation;

public class LevelCAHalloweenSkeletonSkinHandler : LevelCAHalloweenCustomSpineSkinHandler
{
	private const string _PDPrefabName = "Toy_Bone_01_L22"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAHalloweenSkeletonSkinHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

