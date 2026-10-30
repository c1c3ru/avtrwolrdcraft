namespace Game.Level.ContextualAnimation;

public class LevelCATrickOrTreatItemHandler : LevelCAGiftExchangeItemHandler
{
	private const string GIVE_CANDY_ANIMATION_NAME = "CA/Audience/Donate"; //Field offset: 0x0
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0xA8
	[SerializeField]
	protected LevelSecretSolveBroadcaster _secretSolveBroadcaster; //Field offset: 0xB0
	protected readonly Dictionary<Int32, String> SPEACIAL_TREATS_BY_CHARACTER_ID; //Field offset: 0xB8
	protected readonly Dictionary<Int32, Int32> SECRET_ID_BY_CHARACTER_ID; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC8

	public LevelCATrickOrTreatItemHandler() { }

	[CompilerGenerated]
	private void <OnAnimationEvent>b__10_0(LevelItem item) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetGiveAnimationName() { }

	protected virtual Dictionary<Int32, String> GetSpecialGiftsByCharacterIDDictionary() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnGiftReceived(LevelCharacter giver, LevelItem gift) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

