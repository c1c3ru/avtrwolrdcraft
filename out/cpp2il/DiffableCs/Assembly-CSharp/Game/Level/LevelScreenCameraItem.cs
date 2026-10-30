namespace Game.Level;

public class LevelScreenCameraItem : LevelItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public PointerEventData eventData; //Field offset: 0x10
		public LevelScreenCameraItem <>4__this; //Field offset: 0x18
		public LevelCameraScreenPhoto polaroidPhoto; //Field offset: 0x20
		public LevelCameraScreenPhotohItemHandler polaroidPhotoItemHandler; //Field offset: 0x28

		public <>c__DisplayClass12_0() { }

		internal void <OnPointerClickInternal>b__0() { }

		internal void <OnPointerClickInternal>b__1() { }

	}

	[CompilerGenerated]
	private static Action<LevelScreenCaptureCameraItemHandler> OnScreenCaptureAction; //Field offset: 0x0
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x348
	[SerializeField]
	private LevelSpawn _prefab; //Field offset: 0x350
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x358
	[SerializeField]
	private bool _zoomInPhotoOnSpawn; //Field offset: 0x360
	[Range(1, 15)]
	[SerializeField]
	private int _maxInstances; //Field offset: 0x364
	private LevelScreenCaptureCameraItemHandler _screenCaptureHandler; //Field offset: 0x368
	private bool _didZoomPhotoFirstTime; //Field offset: 0x370

	public static event Action<LevelScreenCaptureCameraItemHandler> OnScreenCaptureAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelScreenCameraItem() { }

	[CompilerGenerated]
	public static void add_OnScreenCaptureAction(Action<LevelScreenCaptureCameraItemHandler> value) { }

	protected virtual void Awake() { }

	public void ForceClick() { }

	private string GetImagesDirectory() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnScreenCaptureAction(Action<LevelScreenCaptureCameraItemHandler> value) { }

}

