namespace BWYW;

public abstract class BWYWSlotBase : MonoBehaviour
{
	[CompilerGenerated]
	private bool <IsInteractable>k__BackingField; //Field offset: 0x20
	[SerializeField]
	protected DynamicScrollPoint _dynamicScrollPoint; //Field offset: 0x28
	[SerializeField]
	protected Button _claimButton; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Int32> OnSlotClickAction; //Field offset: 0x38
	[CompilerGenerated]
	private Action<Int32> OnClaimClickAction; //Field offset: 0x40
	protected int _id; //Field offset: 0x48
	protected bool _isCentered; //Field offset: 0x4C

	public event Action<Int32> OnClaimClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Int32> OnSlotClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public Button ClaimButton
	{
		 get { } //Length: 8
	}

	public DynamicScrollPoint DynamicScrollPoint
	{
		 get { } //Length: 8
	}

	public int Id
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

	protected BWYWSlotBase() { }

	[CompilerGenerated]
	public void add_OnClaimClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnSlotClickAction(Action<Int32> value) { }

	protected override void Awake() { }

	public Button get_ClaimButton() { }

	public DynamicScrollPoint get_DynamicScrollPoint() { }

	public int get_Id() { }

	[CompilerGenerated]
	public bool get_IsInteractable() { }

	protected override void OnBeginDrag() { }

	public override void OnClaimClick() { }

	public override void OnClaimClickInternal() { }

	public override void OnClick() { }

	public override bool OnClickInternal() { }

	protected override void OnDestroy() { }

	protected override void OnFocus(ScrollPoint scrollPoint) { }

	protected override void OnFocusLost(ScrollPoint scrollPoint) { }

	[CompilerGenerated]
	public void remove_OnClaimClickAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnSlotClickAction(Action<Int32> value) { }

	public void ResetScale() { }

	[CompilerGenerated]
	public void set_IsInteractable(bool value) { }

}

