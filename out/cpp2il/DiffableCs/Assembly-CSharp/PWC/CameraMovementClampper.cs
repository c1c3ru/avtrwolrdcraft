namespace PWC;

public class CameraMovementClampper : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public CameraMovementClampper <>4__this; //Field offset: 0x10
		public float xStart; //Field offset: 0x18
		public float xDestination; //Field offset: 0x1C

		public <>c__DisplayClass32_0() { }

		internal void <TweenToXPosition>b__0(float value) { }

	}

	internal enum AnchorType
	{
		None = 0,
		Left = 1,
		Right = 2,
	}

	public const float DEFAULT_CAMERA_SIZE = 5,12; //Field offset: 0x0
	public const float TOP = 5,12; //Field offset: 0x0
	public const float BOTTOM = -5,12; //Field offset: 0x0
	public const float HEIGHT = 10,24; //Field offset: 0x0
	[SerializeField]
	protected Camera _camera; //Field offset: 0x20
	[SerializeField]
	private AnchorType _anchorType; //Field offset: 0x28
	protected Transform _cameraTransform; //Field offset: 0x30
	protected bool _isCameraWiderThanScreen; //Field offset: 0x38
	private int _tweenId; //Field offset: 0x3C
	private float _xRightOffset; //Field offset: 0x40
	private GameCameraScrollArea _scrollArea; //Field offset: 0x48
	[CompilerGenerated]
	private Action<Vector2> OnChangePositionAction; //Field offset: 0x50
	[CompilerGenerated]
	private Bounds <ScrollBounds>k__BackingField; //Field offset: 0x58

	public event Action<Vector2> OnChangePositionAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public private Bounds ScrollBounds
	{
		[CompilerGenerated]
		 get { } //Length: 20
		[CompilerGenerated]
		private set { } //Length: 20
	}

	public CameraMovementClampper() { }

	[CompilerGenerated]
	public void add_OnChangePositionAction(Action<Vector2> value) { }

	public void AddXPosition(float xAddition) { }

	public void AddYPosition(float yAddition) { }

	public void FocusOnVector2Position(Vector2 position) { }

	public void FocusOnXPosition(float xPosition) { }

	[CompilerGenerated]
	public Bounds get_ScrollBounds() { }

	public float GetBottomOfScreenFromXPosition(float xPosition) { }

	public Bounds1D GetCameraXBounds() { }

	public Bounds1D GetCameraYBoundsForXPosition(float xPosition) { }

	protected override Bounds1D GetDefaultBaseYBounds() { }

	private float GetScreenWorldHeight() { }

	private float GetScreenWorldWidth() { }

	public float GetScrollBoundsBottomY() { }

	public float GetScrollBoundsHeight() { }

	public float GetScrollBoundsTopY() { }

	public float GetTopOfScreenFromXPosition(float xPosition) { }

	public Camera GetUnityCamera() { }

	[CompilerGenerated]
	public void remove_OnChangePositionAction(Action<Vector2> value) { }

	[CompilerGenerated]
	private void set_ScrollBounds(Bounds value) { }

	public void SetBounds(RectTransform rectTransform) { }

	public void SetBounds(Bounds bounds) { }

	public void SetOffsetToXRightLimit(float offset) { }

	protected void SetPosition(Vector3 position) { }

	protected void SetVector2Position(Vector3 position) { }

	public void StopTween() { }

	public LTDescr TweenToXPosition(float xDestination, float duration, Action onComplete = null) { }

}

