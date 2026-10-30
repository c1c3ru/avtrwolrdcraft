namespace PazuPaint;

public class PaintableTexture : MonoBehaviour
{
	internal enum EnvironmentType
	{
		UI = 0,
		Sprite = 1,
		Spine = 2,
		UICamera = 3,
	}

	internal enum Mode
	{
		PaintTexture = 0,
		PaintColor = 1,
		PaintCover = 2,
		PaintBrush = 3,
		Erase = 4,
		PaintConstrainedAlpha = 5,
	}

	internal enum PaintOnMode
	{
		Transparent = 0,
		ExistingTexture = 1,
	}

	internal sealed class TransformationGetter : MulticastDelegate
	{

		public TransformationGetter(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(out Vector2 position, out Quaternion rotation, out Vector2 scale, AsyncCallback callback, object object) { }

		public override void EndInvoke(out Vector2 position, out Quaternion rotation, out Vector2 scale, IAsyncResult result) { }

		public override void Invoke(out Vector2 position, out Quaternion rotation, out Vector2 scale) { }

	}

	private static readonly Vector2 SPRITE_MIDDLE_PIVOT; //Field offset: 0x0
	[SerializeField]
	private EnvironmentType _environmentType; //Field offset: 0x20
	private RectTransform _rectTrasnform; //Field offset: 0x28
	private RawImage _rawImage; //Field offset: 0x30
	private SpriteRenderer _spriteRenderer; //Field offset: 0x38
	private Camera _camera; //Field offset: 0x40
	private Vector2 _worldTextureSize; //Field offset: 0x48
	private LTexture _texture; //Field offset: 0x50
	private LTexture _paintFromTexture; //Field offset: 0x58
	private LTexture _originalTextureToPaintOn; //Field offset: 0x60
	private Vector2 _imageBottomLeftCorner; //Field offset: 0x68
	private Vector2 _lossyScale; //Field offset: 0x70
	private Quaternion _rotation; //Field offset: 0x78
	private Vector2 _position; //Field offset: 0x88
	private Vector2Int _brushSize; //Field offset: 0x90
	private int _width; //Field offset: 0x98
	private int _height; //Field offset: 0x9C
	private float _brushStrengh; //Field offset: 0xA0
	private int _pixelsPerUnit; //Field offset: 0xA4
	private bool _useFromColorForLerp; //Field offset: 0xA8
	private Vector2 _spritePivot; //Field offset: 0xAC
	private bool _isSpritePivotMiddle; //Field offset: 0xB4
	private Vector2 _paintPositionOffset; //Field offset: 0xB8
	private bool _usePaintPositionOffset; //Field offset: 0xC0
	private LTexture _brush; //Field offset: 0xC8
	private bool _isReadyToPaint; //Field offset: 0xD0
	private Mode _mode; //Field offset: 0xD4
	private PaintOnMode _paintOnMode; //Field offset: 0xD8
	private Color32 _clearColor; //Field offset: 0xDC
	private LMask _mask; //Field offset: 0xE0
	private bool _useMask; //Field offset: 0xE8
	private Byte[] _paintedPixelsAlpha; //Field offset: 0xF0
	private LTexture _previousTexture; //Field offset: 0xF8
	private Color32 _colorToPaintFrom; //Field offset: 0x100
	private Vector2 _lastPaintPosition; //Field offset: 0x104
	private bool _didLastPaintChangedPixelsColor; //Field offset: 0x10C
	private float _minPaintDistance; //Field offset: 0x110
	private float _minPaintDistanceFactor; //Field offset: 0x114
	private bool _dontPaintOnZeroAlpha; //Field offset: 0x118
	private bool _isPlayingLoopSound; //Field offset: 0x119
	private bool _mouseButtonIsDown; //Field offset: 0x11A
	private Color32[] _currentColors; //Field offset: 0x120
	private TransformationGetter _spinePartTransformationGetter; //Field offset: 0x128
	public Action StartPaintSoundLoopAction; //Field offset: 0x130
	public Action StartEraseSoundLoopAction; //Field offset: 0x138
	public Action StopSoundLoopAction; //Field offset: 0x140
	public Action PlayBeginPaintSoundAction; //Field offset: 0x148
	public Action PlayBeginEraseSoundAction; //Field offset: 0x150
	[CompilerGenerated]
	private bool <DidLastPaintAffectedPixels>k__BackingField; //Field offset: 0x158
	public Action<Vector2> OnPaintPositionAction; //Field offset: 0x160
	private bool _isAPIPainting; //Field offset: 0x168
	private Vector2 _paintPosition; //Field offset: 0x16C
	private bool _isPaintingFromTextureWithDifferentSize; //Field offset: 0x174
	private bool _shouldSingleAndPosition; //Field offset: 0x175
	private int _paintPositonXMin; //Field offset: 0x178
	private int _paintPositonYMin; //Field offset: 0x17C
	private int _paintPositonXMax; //Field offset: 0x180
	private int _paintPositonYMax; //Field offset: 0x184
	private bool _useBrushAlphaCutoff; //Field offset: 0x188
	private float _brushAlphaCutoff; //Field offset: 0x18C
	private bool _useBrushAlphaCutoffSmoothness; //Field offset: 0x190
	private float _brushAlphaCutoffSmoothness; //Field offset: 0x194
	[CompilerGenerated]
	private bool <ShouldDestroyTextureOnDestroy>k__BackingField; //Field offset: 0x198
	private bool _didInit; //Field offset: 0x199

	public private bool DidLastPaintAffectedPixels
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public bool DidLastPaintChangedPixelsColor
	{
		 get { } //Length: 8
	}

	public bool ShouldDestroyTextureOnDestroy
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	private static PaintableTexture() { }

	public PaintableTexture() { }

	public void APIPaintingPaint(Vector2 position) { }

	public void APIPaintingStart() { }

	public void APIPaintingStop() { }

	private void Awake() { }

	private void ClearColorArrays() { }

	private void ClearCoverModeData() { }

	public static LTexture CreateBrush(Texture2D brush, float scale = 1, float angle = 0) { }

	public void CreateProperTexture(Texture2D fromTexture) { }

	private Texture2D CreateProperTextureBase() { }

	public void CreateProperTextureIfNeeded() { }

	[CompilerGenerated]
	public bool get_DidLastPaintAffectedPixels() { }

	public bool get_DidLastPaintChangedPixelsColor() { }

	[CompilerGenerated]
	public bool get_ShouldDestroyTextureOnDestroy() { }

	public LTexture GetLTexture() { }

	public LMask GetMask() { }

	public Texture2D GetTexture() { }

	public Vector2 GetUVPosition(Vector2 position) { }

	private void InitArrayIfNeeded(ref Color32[] array) { }

	public void InitIfNeeded() { }

	private void LerpColor(ref Color32 affected, ref Color32 from, ref Color32 to, ref float t) { }

	private void LerpColorNoAlpha(ref Color32 affected, ref Color32 from, ref Color32 to, ref float t) { }

	private void LerpColorOverrideZeroAlpha(ref Color32 affected, ref Color32 from, ref Color32 to, ref float t) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnPointerDown() { }

	private void OnSetTexture() { }

	private bool Paint(bool starting) { }

	private bool Paint(Vector2 uv) { }

	public void PaintStrokeNow() { }

	private void PlayLoopSoundIfNotPlaying() { }

	[CompilerGenerated]
	private void set_DidLastPaintAffectedPixels(bool value) { }

	[CompilerGenerated]
	public void set_ShouldDestroyTextureOnDestroy(bool value) { }

	public void SetBrush(Texture2D brush, float scale = 1, float angle = 0) { }

	public void SetBrush(LTexture brush) { }

	public void SetBrushAlphaCutoff(float alphaCutoff) { }

	public void SetBrushAlphaCutoffSmoothness(float smoothness = 0) { }

	public void SetBrushStrength(float strengh) { }

	public void SetClearColor(Color32 Color) { }

	public void SetColor(Color32 color) { }

	public void SetDontPaintOnZeroAlpha(bool dontPaintOnZeroAlpha) { }

	private void SetImageBottomLeftCorner() { }

	public void SetMask(LMask mask) { }

	public void SetMaskFromTexture(Texture2D texture) { }

	public void SetMaskFromTexture(Texture2D texture, Rect rect) { }

	public void SetMinPaintDistanceFactor(float minPaintDistanceFactor) { }

	public void SetMode(Mode mode) { }

	public void SetPaintPositionOffset(Vector2 offset) { }

	public void SetPaintSingleAndPosition(bool shouldSingleAndPosition, int xPixelOffset = 0, int yPixelOffset = 0) { }

	public void SetPaintSingleAndPosition(bool shouldPosition, Vector2 position) { }

	public void SetPixelsPerUnit(int pixelsPerUnit) { }

	public void SetSize(int width, int height) { }

	public void SetSpinePartTransformationGetter(TransformationGetter getter) { }

	public void SetSpritePivot(Vector2 spritePivot) { }

	public void SetTexture(LTexture texture) { }

	public void SetTexture(Texture2D texture) { }

	private void SetTextureColor(Texture2D texture, Color32 color) { }

	private void SetTextureToEnviromentComponent(Texture2D texture) { }

	public void SetTextureToPaintOn(Texture2D texture) { }

	public void SetUseFromColorForLerp(bool useFromColorForLerp) { }

	private float Smoothstep(float a, float b, float x) { }

	private void StopLoopSoundIfPlaying() { }

	private void StopPainting() { }

	private void Update() { }

	public void UpdateColor(Color32 color) { }

}

