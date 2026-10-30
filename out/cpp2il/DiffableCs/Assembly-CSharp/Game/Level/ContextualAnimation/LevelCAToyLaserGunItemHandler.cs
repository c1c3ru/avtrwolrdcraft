namespace Game.Level.ContextualAnimation;

public class LevelCAToyLaserGunItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private GameObject _laser; //Field offset: 0x88
	[SerializeField]
	private LevelItemInCharacterBoneTransformOverride _bone; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAToyLaserGunItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationEvent>b__4_0() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

