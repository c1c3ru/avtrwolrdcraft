namespace Game.Level.ContextualAnimation;

public class LevelCAXmasGiftExchangerItemHandler : LevelCAGiftExchangeItemHandler
{
	private const string OFFER_GIFT_ANIMATION_NAME = "Offer_Gift"; //Field offset: 0x0
	private const string GIVE_GIFT_ANIMATION_NAME = "CA/Bouquet/Tossing_The_Bouquet"; //Field offset: 0x0
	[SerializeField]
	private PDPrefabReference[] _giftWrapPDPrefabReferences; //Field offset: 0xA8
	[SerializeField]
	private PDPrefabReference _specialGiftWrapPDPrefabReferences; //Field offset: 0xB0
	private string _currentGiftPDGuid; //Field offset: 0xB8
	private LevelCharacter _currentClosestCharacter; //Field offset: 0xC0
	protected readonly Dictionary<Int32, String> SPECIAL_GIFTS_BY_CHARACTER_ID; //Field offset: 0xC8
	protected readonly Dictionary<Int32, String> SPECIAL_CLOTHING_GIFTS_BY_CHARACTER_ID; //Field offset: 0xD0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xD8

	public LevelCAXmasGiftExchangerItemHandler() { }

	protected virtual LevelItem CreateClothingGift(LevelCharacter character, string pdPrefabGUID) { }

	protected virtual LevelItem CreateGift(LevelCharacter character, string pdPrefabGUID) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetGiveAnimationName() { }

	protected virtual List<LevelCharacter> GetRelevantCharactersInCircle() { }

	protected virtual Dictionary<Int32, String> GetSpecialClothingGiftsByCharacterIDDictionary() { }

	protected virtual Dictionary<Int32, String> GetSpecialGiftsByCharacterIDDictionary() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void OnBeginThrowToMe(LevelItem levelItem) { }

	private void OnItemGiven(LevelItem levelItem) { }

	private void OnItemRecieve(LevelItem levelItem) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public virtual bool ShouldReturnToIdleAnimationAtEndOfAnimation() { }

	private void StartGivingSequence(TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

