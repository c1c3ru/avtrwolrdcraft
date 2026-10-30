namespace Game.Level.ContextualAnimation;

public class LevelCADonkeyTailItemHandler : LevelCAItemHandlerBase
{
	private enum TailTypeEnum
	{
		DonkeyTail = 0,
		Tiara = 1,
		DinosaurTail = 2,
	}

	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private TailTypeEnum _tailTypeEnum; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configsDonkeyTail; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configsTiara; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configsDinosaurTail; //Field offset: 0xA8

	public LevelCADonkeyTailItemHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

