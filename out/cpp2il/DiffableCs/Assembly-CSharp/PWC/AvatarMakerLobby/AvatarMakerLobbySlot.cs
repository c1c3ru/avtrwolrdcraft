namespace PWC.AvatarMakerLobby;

public abstract class AvatarMakerLobbySlot : MonoBehaviour
{
	[CompilerGenerated]
	private bool <IsInteractable>k__BackingField; //Field offset: 0x20
	[SerializeField]
	protected DynamicScrollPoint _dynamicScrollPoint; //Field offset: 0x28
	[SerializeField]
	private GameObject _animationParent; //Field offset: 0x30
	protected bool _isCentered; //Field offset: 0x38
	private float _lowerYLocalPosition; //Field offset: 0x3C
	private float _upperYLocalPosition; //Field offset: 0x40

	public DynamicScrollPoint DynamicScrollPoint
	{
		 get { } //Length: 8
	}

	public bool IsInteractable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	protected AvatarMakerLobbySlot() { }

	private void AnimateCentered(bool value) { }

	protected override void Awake() { }

	public DynamicScrollPoint get_DynamicScrollPoint() { }

	[CompilerGenerated]
	public bool get_IsInteractable() { }

	protected override void OnBeginDrag() { }

	private void OnClick() { }

	protected override bool OnClickInternal() { }

	protected override void OnDestroy() { }

	protected override void OnFocus(ScrollPoint scrollPoint) { }

	protected override void OnFocusLost(ScrollPoint scrollPoint) { }

	public void ResetScale() { }

	[CompilerGenerated]
	public void set_IsInteractable(bool value) { }

}

