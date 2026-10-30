namespace PWC.CarsMaker;

public class CarMakerCameraFocus : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public CarMakerCameraFocus <>4__this; //Field offset: 0x10
		public int categoryType; //Field offset: 0x18

		public <>c__DisplayClass32_0() { }

		internal void <OnCategoryButtonClick>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public CarMakerCameraFocus <>4__this; //Field offset: 0x10
		public Vector3 fromPosition; //Field offset: 0x18
		public Vector3 toPosition; //Field offset: 0x24
		public float fromSize; //Field offset: 0x30
		public float toSize; //Field offset: 0x34

		public <>c__DisplayClass37_0() { }

		internal void <Focus>b__0(float progress) { }

	}

	[SerializeField]
	private Camera _camera; //Field offset: 0x20
	[SerializeField]
	private float _defaultZoomRatio; //Field offset: 0x28
	[FormerlySerializedAs("_globalOffset")]
	[SerializeField]
	private Vector2 _globalOffsetWide; //Field offset: 0x2C
	[SerializeField]
	private Vector2 _globalOffsetVeryWide; //Field offset: 0x34
	[SerializeField]
	private Vector2 _globalOffsetIpad; //Field offset: 0x3C
	[SerializeField]
	private Vector2 _fullViewOffsetWide; //Field offset: 0x44
	[SerializeField]
	private Vector2 _fullViewOffsetVeryWide; //Field offset: 0x4C
	[SerializeField]
	private Vector2 _fullViewOffsetIpad; //Field offset: 0x54
	[SerializeField]
	private bool _keepViewInsideBackground; //Field offset: 0x5C
	[SerializeField]
	private bool _offsetByMenuWidth; //Field offset: 0x5D
	[SerializeField]
	private RectTransform _menuRect; //Field offset: 0x60
	[SerializeField]
	private float _focusDuration; //Field offset: 0x68
	[SerializeField]
	private LeanTweenType _ease; //Field offset: 0x6C
	private Vector3 _defaultPosition; //Field offset: 0x70
	private float _defaultSize; //Field offset: 0x7C
	private readonly Vector3[] _menuCorners; //Field offset: 0x80
	private GameObject _backgroundObject; //Field offset: 0x88
	private Bounds _backgroundBounds; //Field offset: 0x90
	private bool _hasBackgroundBounds; //Field offset: 0xA8
	private Vector3 _focusedWorldPoint; //Field offset: 0xAC
	private float _focusedZoomRatio; //Field offset: 0xB8
	private bool _hasCloseFraming; //Field offset: 0xBC
	private bool _isZoomedOut; //Field offset: 0xBD
	[CompilerGenerated]
	private Action OnZoomStateChangedAction; //Field offset: 0xC0

	public event Action OnZoomStateChangedAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public bool CanZoomOut
	{
		 get { } //Length: 8
	}

	public bool IsZoomedOut
	{
		 get { } //Length: 8
	}

	public CarMakerCameraFocus() { }

	[CompilerGenerated]
	public void add_OnZoomStateChangedAction(Action value) { }

	private void ApplyFraming(Vector3 position, float orthographicSize) { }

	private void Awake() { }

	private static float ClampAxis(float position, float min, float max, float halfView) { }

	private Vector3 ClampToBackground(Vector3 position, float orthographicSize) { }

	private void Focus(Vector3 worldPoint, float zoomRatio) { }

	private void FocusOnCategory(CarCategoryType categoryType) { }

	private void FocusOnDefault() { }

	public bool get_CanZoomOut() { }

	public bool get_IsZoomedOut() { }

	private Vector2 GetFullViewOffset() { }

	private Vector2 GetGlobalOffset() { }

	private float GetMenuOffsetX(float orthographicSize) { }

	private float GetSizeInsideBackground(float orthographicSize) { }

	private void OnCategoryButtonClick(int categoryType) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public void remove_OnZoomStateChangedAction(Action value) { }

	private void SetCloseFraming(Vector3 worldPoint, float zoomRatio, bool hasCloseFraming) { }

	public void ToggleZoom() { }

	private bool TryGetBackgroundBounds(out Bounds bounds) { }

	private static bool TryGetCarView(out CarView carView) { }

	private bool TryGetMenuRect(out RectTransform menuRect) { }

}

