namespace Game.Level.ContextualAnimation;

public class LevelCAItemCharacterHairCombHandler : LevelCAItemHandlerBase
{
	internal enum HairSetNumber
	{
		One = 1,
		Two = 2,
		Three = 3,
	}

	[SerializeField]
	private HairSetNumber _hairSetNumber; //Field offset: 0x88
	private string _currentExtraData; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configsSet_1; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configsSet_2; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configsSet_3; //Field offset: 0xA8

	public LevelCAItemCharacterHairCombHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public void OnAvatarSetHair(ILevelAvatar avatar) { }

}

