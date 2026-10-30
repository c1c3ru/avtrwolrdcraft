namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyPlatform : MonoBehaviour
{
	internal enum AvatarMakerLobbyPlatformSize
	{
		Regular = 0,
		Big = 1,
		Empty = 2,
	}

	internal enum AvatarMakerLobbyPlatformType
	{
		None = 0,
		AvatarMaker = 1,
		CarMaker = 2,
	}

	public const float ANIMATION_TIME = 0,15; //Field offset: 0x0
	public const float ANIMATION_HEIGHT = 0,35; //Field offset: 0x0
	private const float CAR_SLOT_MASK_Y_POSITION = -3,14; //Field offset: 0x0
	private const float CAR_PLATFORM_BIG_SCALE = 2; //Field offset: 0x0
	private const float CAR_PLATFORM_REGULAR_SCALE = 1,1; //Field offset: 0x0
	private const float CAR_PLATFORM_EMPTY_SCALE = 0,85; //Field offset: 0x0
	[SerializeField]
	private Sprite _avatarMakerPlatformSprite; //Field offset: 0x20
	[SerializeField]
	private Sprite _carMakerPlatformSprite; //Field offset: 0x28
	[SerializeField]
	private SpriteMask _mask; //Field offset: 0x30
	[SerializeField]
	private Sprite _avatarMakerPlatformMaskSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _carMakerPlatformMaskSprite; //Field offset: 0x40
	private float _lowerYPosition; //Field offset: 0x48
	private float _upperYPosition; //Field offset: 0x4C
	private int _moveTweenID; //Field offset: 0x50
	private int _sizeTweenID; //Field offset: 0x54
	private float _horizontalScale; //Field offset: 0x58
	private float _targetScale; //Field offset: 0x5C
	private float _regularScale; //Field offset: 0x60
	private float _emptyScale; //Field offset: 0x64

	public AvatarMakerLobbyPlatform() { }

	private void Animate(bool value) { }

	private static void ApplyHorizontalScale(Transform target, float scale) { }

	private void Awake() { }

	private void CancelTween(ref int tweenID) { }

	private void OnBeginDrag() { }

	private void OnDestroy() { }

	private void OnFocus(ScrollPoint _) { }

	private void OnFocusLost(ScrollPoint _) { }

	public void ResetPosition() { }

	private void SetHorizontalScale(float scale) { }

	public void SetPlatformType(AvatarMakerLobbyPlatformType platformType) { }

	public void SetSize(AvatarMakerLobbyPlatformSize size, bool immediate = false) { }

	private void SetSizeImmediate(float scale) { }

}

