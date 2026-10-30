namespace PWC.Level;

[RequireComponent(typeof(LevelItem))]
public class LevelFlippableItemHandler : MonoBehaviour
{
	internal enum OnBoneStateType
	{
		None = 0,
		NotFlipped = 1,
		Flipped = 2,
	}

	[SerializeField]
	private OnBoneStateType _onBoneState; //Field offset: 0x20
	[SerializeField]
	private bool _allowFlipWhileDragging; //Field offset: 0x24
	[SerializeField]
	private float _dragFlipXDelta; //Field offset: 0x28
	private LevelItem _levelItem; //Field offset: 0x30

	public bool AllowFlipWhileDragging
	{
		 get { } //Length: 8
	}

	public LevelFlippableItemHandler() { }

	private void Awake() { }

	public bool get_AllowFlipWhileDragging() { }

	private void OnBeforePlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private void OnDestroy() { }

	public void OnItemSyncPosition(float pointerXPosition, float lastPointerXPosition) { }

	public void SetOnBoneState(OnBoneStateType onBoneStateType) { }

}

