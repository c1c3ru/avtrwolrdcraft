namespace PWC;

public class GameCameraBase : CameraMovementClampper, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public Camera camera; //Field offset: 0x10
		public float fromSize; //Field offset: 0x18
		public float orthographicScale; //Field offset: 0x1C
		public Vector3 fromPos; //Field offset: 0x20
		public Vector2 targetPosition; //Field offset: 0x2C
		public GameCameraBase <>4__this; //Field offset: 0x38

		public <>c__DisplayClass46_0() { }

		internal void <ZoomOn>b__0(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public Camera camera; //Field offset: 0x10
		public float fromSize; //Field offset: 0x18
		public float targetScale; //Field offset: 0x1C
		public Vector3 fromPos; //Field offset: 0x20
		public GameCameraBase <>4__this; //Field offset: 0x30

		public <>c__DisplayClass47_0() { }

		internal void <ZoomBackToDefault>b__0(float value) { }

		internal void <ZoomBackToDefault>b__1() { }

	}

	public static readonly Dictionary<Scene, GameCameraBase> Instances; //Field offset: 0x0
	[SerializeField]
	protected CShapeRaycaster _cShapeRaycaster; //Field offset: 0x70
	[CompilerGenerated]
	private bool <ShouldConsiderCShapes>k__BackingField; //Field offset: 0x78
	private Nullable<Vector2> _lastMousePosition; //Field offset: 0x7C
	private bool _isPointerDown; //Field offset: 0x88
	private bool _isDragging; //Field offset: 0x89
	private float _dragFactor; //Field offset: 0x8C
	public bool isDraggable; //Field offset: 0x90
	[CompilerGenerated]
	private Action OnBeginDragAction; //Field offset: 0x98
	[CompilerGenerated]
	private Action OnEndDragAction; //Field offset: 0xA0
	[CompilerGenerated]
	private Action OnPointerDownAction; //Field offset: 0xA8
	[CompilerGenerated]
	private Action OnZoomInAction; //Field offset: 0xB0
	[CompilerGenerated]
	private Action OnZoomBackToDefaultAction; //Field offset: 0xB8
	[CompilerGenerated]
	private bool <AllowMovementWhenZoomNotDefault>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private bool <IsZoomNotDefault>k__BackingField; //Field offset: 0xC1

	public event Action OnBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnEndDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnPointerDownAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnZoomBackToDefaultAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnZoomInAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public bool AllowMovementWhenZoomNotDefault
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public private bool IsZoomNotDefault
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public bool ShouldConsiderCShapes
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	private static GameCameraBase() { }

	public GameCameraBase() { }

	[CompilerGenerated]
	public void add_OnBeginDragAction(Action value) { }

	[CompilerGenerated]
	public void add_OnEndDragAction(Action value) { }

	[CompilerGenerated]
	public void add_OnPointerDownAction(Action value) { }

	[CompilerGenerated]
	public void add_OnZoomBackToDefaultAction(Action value) { }

	[CompilerGenerated]
	public void add_OnZoomInAction(Action value) { }

	protected override void Awake() { }

	[CompilerGenerated]
	public bool get_AllowMovementWhenZoomNotDefault() { }

	[CompilerGenerated]
	public bool get_IsZoomNotDefault() { }

	[CompilerGenerated]
	public bool get_ShouldConsiderCShapes() { }

	public CShapeRaycaster GetCShapeRaycaster() { }

	public static GameCameraBase GetCurrentCamera(Scene scene) { }

	public static GameCameraBase GetCurrentCamera(GameObject obj) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public bool IsCurrentZoomedIn() { }

	protected override void OnBeginDrag() { }

	protected override void OnDestroy() { }

	private void OnDrag() { }

	protected override void OnEndDrag() { }

	private void PlayEndDragTween() { }

	[CompilerGenerated]
	public void remove_OnBeginDragAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnEndDragAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnPointerDownAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnZoomBackToDefaultAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnZoomInAction(Action value) { }

	private void RemoveSelfFromInstances() { }

	[CompilerGenerated]
	public void set_AllowMovementWhenZoomNotDefault(bool value) { }

	[CompilerGenerated]
	private void set_IsZoomNotDefault(bool value) { }

	[CompilerGenerated]
	public void set_ShouldConsiderCShapes(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected override bool ShouldSaveZoomStateInPersistentData() { }

	protected override void Update() { }

	public void ZoomBackToDefault(float targetScale = 5,12) { }

	public void ZoomOn(Vector2 targetPosition, float orthographicScale = 2,56, bool snap = false) { }

}

