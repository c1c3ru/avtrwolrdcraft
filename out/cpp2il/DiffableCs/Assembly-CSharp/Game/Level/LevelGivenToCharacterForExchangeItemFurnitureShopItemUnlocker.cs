namespace Game.Level;

public class LevelGivenToCharacterForExchangeItemFurnitureShopItemUnlocker : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	protected string _chairGUID; //Field offset: 0x28
	[SerializeField]
	private string _prizeDropAreaGuid; //Field offset: 0x30
	[SerializeField]
	protected PDPrefabReference _giftBox; //Field offset: 0x38
	[SerializeField]
	protected string _prizeSoundName; //Field offset: 0x40
	[SerializeField]
	protected LevelDrawSketchArea _levelDrawSketchArea; //Field offset: 0x48
	[SerializeField]
	protected Sprite _stampSpriteToDraw; //Field offset: 0x50
	[SerializeField]
	private SpriteRenderer _stampSpriteRenderer; //Field offset: 0x58
	[SerializeField]
	private PDPrefabReference _stamperItem; //Field offset: 0x60
	[SerializeField]
	private string _giveAnimationName; //Field offset: 0x68
	private string employeeShirt_1; //Field offset: 0x70
	private string employeeShirt_2; //Field offset: 0x78
	private bool _isStamped; //Field offset: 0x80
	private bool _isRevealed; //Field offset: 0x81
	private bool _isSwitchingHand; //Field offset: 0x82
	private LevelItem _stamper; //Field offset: 0x88
	private LevelCharacter _currentCharacter; //Field offset: 0x90

	public LevelGivenToCharacterForExchangeItemFurnitureShopItemUnlocker() { }

	protected void Awake() { }

	private void EnsureHand(ILevelHasHands target, AvatarHandType characterHandType) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnAnimationEnd(TrackEntry trackEntry) { }

	private void OnAnimationEvent(TrackEntry trackEntry, Event e) { }

	private void OnAnimationInterrupt(TrackEntry trackEntry) { }

	protected void OnDestroy() { }

	protected override void OnPlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType type) { }

	private void RevealNewFurniture() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Stamp(LevelCharacter levelCharacter) { }

	private void ToggleStamper(bool state) { }

}

