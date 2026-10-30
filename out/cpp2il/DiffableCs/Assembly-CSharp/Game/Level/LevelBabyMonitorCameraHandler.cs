namespace Game.Level;

public class LevelBabyMonitorCameraHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelBabyMonitorScreenHandler, Boolean> <>9__15_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <OnReadyPostLoad>b__15_0(LevelBabyMonitorScreenHandler bms) { }

	}

	public static HashSet<LevelBabyMonitorCameraHandler> BabyMonitorCameras; //Field offset: 0x0
	[SerializeField]
	private LevelScreenCaptureCameraItemHandler _screenCaptureItemHandler; //Field offset: 0x20
	private bool _didOnReadyPostLoad; //Field offset: 0x28
	private LevelBabyMonitorScreenHandler _babyMonitorScreenHandler; //Field offset: 0x30
	private LevelItem _babyMonitorScreenLevelItem; //Field offset: 0x38

	public LevelBabyMonitorScreenHandler BabyMonitorScreenHandler
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelScreenCaptureCameraItemHandler ScreenCaptureItemHandler
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static LevelBabyMonitorCameraHandler() { }

	public LevelBabyMonitorCameraHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	public LevelBabyMonitorScreenHandler get_BabyMonitorScreenHandler() { }

	public LevelScreenCaptureCameraItemHandler get_ScreenCaptureItemHandler() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	protected void OnLevelPostInit() { }

	private void OnPreDestroy(LevelItem levelItem) { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	public void set_BabyMonitorScreenHandler(LevelBabyMonitorScreenHandler value) { }

	public void set_ScreenCaptureItemHandler(LevelScreenCaptureCameraItemHandler value) { }

	public void SetNewMonitorScreen(MeshRenderer newPreview) { }

}

