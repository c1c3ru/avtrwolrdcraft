namespace Game.Level;

public class LevelEnsurePickupItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	private ILevelAvatar _avatar; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsHeldInHand>k__BackingField; //Field offset: 0x30

	public bool IsHeldInHand
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelEnsurePickupItemHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_IsHeldInHand() { }

	private void OnDestroy() { }

	public void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public void OnRemovedFromAvatar(ILevelAvatar avatar) { }

	public void PlayPickUpAnimation(DragDropItemBase item, PointerEventData eventData) { }

	[CompilerGenerated]
	public void set_IsHeldInHand(bool value) { }

}

