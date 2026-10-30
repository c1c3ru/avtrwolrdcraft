namespace PWC;

public class InteractableItem : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[SerializeField]
	private bool _hasNoCShape; //Field offset: 0x20
	[SerializeField]
	private CShape _cShape; //Field offset: 0x28
	[CompilerGenerated]
	private GameShape <MyGameShape>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private bool <ShouldLockCShapeOnPointerDownUpEvents>k__BackingField; //Field offset: 0x38

	public CShape MyCShape
	{
		 get { } //Length: 8
	}

	public private GameShape MyGameShape
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public bool ShouldLockCShapeOnPointerDownUpEvents
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public InteractableItem() { }

	protected override void Awake() { }

	protected override GameShape CreateGameShape() { }

	public CShape get_MyCShape() { }

	[CompilerGenerated]
	public GameShape get_MyGameShape() { }

	[CompilerGenerated]
	public bool get_ShouldLockCShapeOnPointerDownUpEvents() { }

	public Bounds1D GetLocalXBounds() { }

	public Bounds1D GetWorldXBounds() { }

	public void LockEventSystemToCurrentCShape() { }

	protected override void OnCShapeSynced() { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	[CompilerGenerated]
	private void set_MyGameShape(GameShape value) { }

	[CompilerGenerated]
	public void set_ShouldLockCShapeOnPointerDownUpEvents(bool value) { }

	public void SetCShape(CShape cShape, bool forceUpdateTransformData = true) { }

	protected void SyncCurrentCShape(bool forceUpdateTransformData = true) { }

	public void UnlockEventSystemFromCurrentCShape() { }

}

