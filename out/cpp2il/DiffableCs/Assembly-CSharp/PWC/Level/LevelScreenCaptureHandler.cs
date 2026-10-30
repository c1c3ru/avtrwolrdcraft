namespace PWC.Level;

public class LevelScreenCaptureHandler : MonoBehaviour, ILevelSpawnDuringGameplay, ILevelMakerUIMenuItem
{
	[SerializeField]
	protected RectTransform _captureRect; //Field offset: 0x20
	[SerializeField]
	protected MeshRenderer _preview; //Field offset: 0x28
	[SerializeField]
	protected Camera _captureCamera; //Field offset: 0x30
	[SerializeField]
	protected bool _clampToScrollBounds; //Field offset: 0x38
	private GameObject _mask; //Field offset: 0x40
	private GameObject[] _spriteRanderers; //Field offset: 0x48
	private bool _isVisable; //Field offset: 0x50
	private RenderTexture _renderTexture; //Field offset: 0x58
	protected Bounds _captureCameraLocalBounds; //Field offset: 0x60
	private bool _didInitScreenCamera; //Field offset: 0x78
	private readonly int _MainTexID; //Field offset: 0x7C

	public LevelScreenCaptureHandler() { }

	protected override void Awake() { }

	protected override bool CanCaptureShowItself() { }

	protected void CheckForVisbility() { }

	protected Bounds ClampBounds(Bounds smallerBounds, Bounds boundingBounds) { }

	public Texture2D CreateTextureFromCapture() { }

	private void EnsureCullingMask() { }

	public override void FixCaptureCameraPosition() { }

	public List<ILevelAvatar> GetAllAvatarsInCapturedScreen() { }

	public Bounds GetCapturedScreenBounds() { }

	public bool HasRendererTexture() { }

	private void InitScreenCamera() { }

	private void InitScreenCameraIfNeeded() { }

	private bool IsCaptureShowItself() { }

	protected override bool IsFlipablePreview() { }

	protected override bool IsParentFliped() { }

	private void OnBecameInvisible() { }

	private void OnBecameVisible() { }

	protected override void OnDestroy() { }

	private void OnEnable() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	protected override void OnSyncPosition(DragDropItemBase item, Vector2 pointerPosition) { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	private void SetInvisibleForCupture(bool visible) { }

	public void SetPreview(MeshRenderer preview) { }

	private void SyncPreview() { }

	public void SyncPreview(MeshRenderer preview) { }

	protected void SyncPreviewIsFlippedState(bool isFlipped) { }

}

