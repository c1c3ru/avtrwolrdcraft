namespace Game.Level.ContextualAnimation;

public class LevelCAHairWaterSprayItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x90

	public LevelCAHairWaterSprayItemHandler() { }

	[CompilerGenerated]
	internal static LevelCAConfig <GetAnimations>g__Get|2_0(ItemOnAvatarType itemOnAvatarType) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

