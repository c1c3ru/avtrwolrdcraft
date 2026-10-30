//Type is in global namespace

public class ListPositionCtrl : MonoBehaviour, IControlEventHandler, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Vector2> <>9__70_2; //Field offset: 0x8
		public static Action<PointerEventData, TouchPhase> <>9__70_3; //Field offset: 0x10
		public static Action<Vector2> <>9__70_4; //Field offset: 0x18
		public static Action<PointerEventData, TouchPhase> <>9__70_5; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <InitializeInputFunction>b__70_2(Vector2 v) { }

		internal void <InitializeInputFunction>b__70_3(PointerEventData pointer, TouchPhase phase) { }

		internal void <InitializeInputFunction>b__70_4(Vector2 v) { }

		internal void <InitializeInputFunction>b__70_5(PointerEventData pointer, TouchPhase phase) { }

	}

	internal enum ControlMode
	{
		Drag = 0,
		Function = 1,
		MouseWheel = 2,
	}

	internal enum Direction
	{
		Vertical = 0,
		Horizontal = 1,
	}

	internal enum ListType
	{
		Circular = 0,
		Linear = 1,
	}

	internal enum PositionState
	{
		Top = 0,
		Middle = 1,
		Bottom = 2,
	}

	[CompilerGenerated]
	private static Action OnInitAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<ListBox> OnStopAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<PointerEventData> OnBeginDragAction; //Field offset: 0x10
	[CompilerGenerated]
	private static Action OnInstanceInitAction; //Field offset: 0x18
	[Tooltip("The type of the list.")]
	public ListType listType; //Field offset: 0x20
	[Tooltip("The controlling mode of the list.")]
	public ControlMode controlMode; //Field offset: 0x24
	[Tooltip("Should a box align in the middle of the list after sliding?")]
	public bool alignMiddle; //Field offset: 0x28
	[Tooltip("The major moving direction of the list.")]
	public Direction direction; //Field offset: 0x2C
	[Tooltip("The boxes which belong to this list.")]
	public ListBox[] listBoxes; //Field offset: 0x30
	[Tooltip("The distance between each box. The larger, the closer.")]
	public float boxDensity; //Field offset: 0x38
	[Tooltip("The curve specifying the box position. The x axis is the major position of the box, which is mapped to [0, 1]. The y axis defines the factor of the passive position of the box. Point (0.5, 0) is the center of the list layout.")]
	public AnimationCurve boxPositionCurve; //Field offset: 0x40
	[Tooltip("The curve specifying the box scale. The x axis is the major position of the box, which is mapped to [0, 1]. The y axis specifies the value of 'localScale' of the box at the corresponding position.")]
	public AnimationCurve boxScaleCurve; //Field offset: 0x48
	[Tooltip("The curve specifying the movement of the box. The x axis is the moving duration in seconds, which starts from 0. The y axis is the factor of the releasing velocity in Drag mode, or the factor of the target position in Function and Mouse Wheel modes.")]
	public AnimationCurve boxMovementCurve; //Field offset: 0x50
	[Tooltip("The callbacks for the event of the clicking on boxes.The registered callbacks will be added to the 'onClick' event of boxes, therefore, boxes should be 'Button's.")]
	public ListBoxClickEvent onBoxClick; //Field offset: 0x58
	public ListEvent onListMove; //Field offset: 0x60
	private Canvas _parentCanvas; //Field offset: 0x68
	private float _canvasMaxPos; //Field offset: 0x70
	[CompilerGenerated]
	private float <unitPos>k__BackingField; //Field offset: 0x74
	[CompilerGenerated]
	private float <lowerBoundPos>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private float <upperBoundPos>k__BackingField; //Field offset: 0x7C
	private Action<PointerEventData, TouchPhase> _inputPositionHandler; //Field offset: 0x80
	private Action<Vector2> _scrollHandler; //Field offset: 0x88
	private IMovementCtrl _movementCtrl; //Field offset: 0x90
	private float _deltaInputPos; //Field offset: 0x98
	private float _deltaDistanceToCenter; //Field offset: 0x9C
	private PositionState _positionState; //Field offset: 0xA0
	[HideInInspector]
	public int numOfUpperDisabledBoxes; //Field offset: 0xA4
	[HideInInspector]
	public int numOfLowerDisabledBoxes; //Field offset: 0xA8
	private int _maxNumOfDisabledBoxes; //Field offset: 0xAC
	[CompilerGenerated]
	private Action<ListBox> OnInstanceStopAction; //Field offset: 0xB0
	[CompilerGenerated]
	private Action<PointerEventData> OnInstanceBeginDragAction; //Field offset: 0xB8
	private bool _isInited; //Field offset: 0xC0
	private bool _isStopped; //Field offset: 0xC1
	[CompilerGenerated]
	private bool <IsDragging>k__BackingField; //Field offset: 0xC2
	[CompilerGenerated]
	private bool <IsMoving>k__BackingField; //Field offset: 0xC3

	[Obsolete("USE OnInstanceBeginDragAction Instead!")]
	public static event Action<PointerEventData> OnBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	[Obsolete("USE OnInstanceInitAction Instead!")]
	public static event Action OnInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public event Action<PointerEventData> OnInstanceBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public static event Action OnInstanceInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public event Action<ListBox> OnInstanceStopAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	[Obsolete("USE OnInstanceStopAction Instead!")]
	public static event Action<ListBox> OnStopAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public bool IsDragging
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public bool IsMoving
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private float lowerBoundPos
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private float unitPos
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private float upperBoundPos
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public ListPositionCtrl() { }

	[CompilerGenerated]
	private float <InitializeInputFunction>b__70_0() { }

	[CompilerGenerated]
	private PositionState <InitializeInputFunction>b__70_1() { }

	[CompilerGenerated]
	public static void add_OnBeginDragAction(Action<PointerEventData> value) { }

	[CompilerGenerated]
	public static void add_OnInitAction(Action value) { }

	[CompilerGenerated]
	public void add_OnInstanceBeginDragAction(Action<PointerEventData> value) { }

	[CompilerGenerated]
	public static void add_OnInstanceInitAction(Action value) { }

	[CompilerGenerated]
	public void add_OnInstanceStopAction(Action<ListBox> value) { }

	[CompilerGenerated]
	public static void add_OnStopAction(Action<ListBox> value) { }

	private void DragPositionHandler(PointerEventData pointer, TouchPhase state) { }

	private void FindDeltaDistanceToCenter() { }

	[CompilerGenerated]
	public bool get_IsDragging() { }

	[CompilerGenerated]
	public bool get_IsMoving() { }

	[CompilerGenerated]
	public float get_lowerBoundPos() { }

	[CompilerGenerated]
	public float get_unitPos() { }

	[CompilerGenerated]
	public float get_upperBoundPos() { }

	public ListBox GetCenteredBox() { }

	public int GetCenteredContentID() { }

	private float GetDeltaTime() { }

	private float GetInputCanvasPosition(Vector3 pointerPosition) { }

	public void Init() { }

	private void InitializeBoxDependency() { }

	private void InitializeInputFunction() { }

	private void InitializePositionVars() { }

	private void LateUpdate() { }

	public void MoveOneUnitDown(int steps = 1) { }

	public void MoveOneUnitUp(int steps = 1) { }

	public void MoveToListBox(ListBox listBox) { }

	public void MoveToListBoxIndex(int listBoxIndex) { }

	public override void OnBeginDrag(PointerEventData pointer) { }

	public override void OnDrag(PointerEventData pointer) { }

	public override void OnEndDrag(PointerEventData pointer) { }

	public override void OnScroll(PointerEventData pointer) { }

	[CompilerGenerated]
	public static void remove_OnBeginDragAction(Action<PointerEventData> value) { }

	[CompilerGenerated]
	public static void remove_OnInitAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnInstanceBeginDragAction(Action<PointerEventData> value) { }

	[CompilerGenerated]
	public static void remove_OnInstanceInitAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnInstanceStopAction(Action<ListBox> value) { }

	[CompilerGenerated]
	public static void remove_OnStopAction(Action<ListBox> value) { }

	public void ResetList(bool deleteAll = true) { }

	private void ScrollDeltaHandler(Vector2 mouseScrollDelta) { }

	[CompilerGenerated]
	public void set_IsDragging(bool value) { }

	[CompilerGenerated]
	public void set_IsMoving(bool value) { }

	[CompilerGenerated]
	private void set_lowerBoundPos(float value) { }

	[CompilerGenerated]
	private void set_unitPos(float value) { }

	[CompilerGenerated]
	private void set_upperBoundPos(float value) { }

	private void SetUnitMove(int unit) { }

	private void Update() { }

	private void UpdatePositionState() { }

}

