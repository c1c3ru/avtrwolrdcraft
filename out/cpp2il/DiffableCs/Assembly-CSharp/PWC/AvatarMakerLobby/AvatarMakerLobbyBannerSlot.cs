namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyBannerSlot : AvatarMakerLobbySlot
{
	private const string CHARACTERS_PACK_NAME = "CharactersPack"; //Field offset: 0x0
	private const string PETS_PACK_NAME = "PetsSlotsP101Pack"; //Field offset: 0x0
	[SerializeField]
	private Image _avatarImage; //Field offset: 0x48
	[SerializeField]
	private GameObject _defaultShopIcon; //Field offset: 0x50
	[SerializeField]
	private GameObject _carShopIcon; //Field offset: 0x58
	private bool _isGameUnlockedOnAwake; //Field offset: 0x60

	public AvatarMakerLobbyBannerSlot() { }

	protected virtual void Awake() { }

	private int GetPackItemIndexToFocusOn() { }

	private void Init() { }

	protected virtual bool OnClickInternal() { }

	protected virtual void OnDestroy() { }

	private void OnUserSync(SyncType syncType) { }

}

