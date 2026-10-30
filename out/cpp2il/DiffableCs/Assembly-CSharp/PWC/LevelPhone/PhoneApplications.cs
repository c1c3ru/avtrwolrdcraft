namespace PWC.LevelPhone;

public class PhoneApplications : GameUIElement, IApplicationsOwner
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Application> <>9__9_0; //Field offset: 0x8
		public static Predicate<Application> <>9__10_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__9_0(Application application) { }

		internal bool <InitCamera>b__10_0(Application application) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public ApplicationsStateList stateList; //Field offset: 0x10
		public PhoneApplications <>4__this; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <InitApplicationsStatesIfNeeded>b__0(Application application) { }

		internal void <InitApplicationsStatesIfNeeded>b__3(Application application) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_1
	{
		public string key; //Field offset: 0x10

		public <>c__DisplayClass11_1() { }

		internal bool <InitApplicationsStatesIfNeeded>b__1(ApplicationState downloadState) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_2
	{
		public ApplicationsStateList newStateList; //Field offset: 0x10

		public <>c__DisplayClass11_2() { }

		internal void <InitApplicationsStatesIfNeeded>b__2(Application application) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public string key; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <SetDownloaded>b__0(ApplicationState downloadState) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public bool value; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal void <Animate>b__0(NonDrawingGraphic nonDrawingGraphic) { }

		internal void <Animate>b__1(Application application) { }

	}

	private const string APPLICATIONS_STATE_LIST_KEY = "PhoneApplications_ApplicationsStatesList"; //Field offset: 0x0
	[SerializeField]
	private AppsContent _appsContent; //Field offset: 0x28
	[SerializeField]
	private GameObject _viewport; //Field offset: 0x30
	[SerializeField]
	private List<NonDrawingGraphic> _nonDrawingGraphics; //Field offset: 0x38
	[SerializeField]
	private List<Application> _applications; //Field offset: 0x40
	private GameObject _cameraApp; //Field offset: 0x48
	private Application _apps; //Field offset: 0x50
	private bool _isInitedApplications; //Field offset: 0x58

	public PhoneApplications() { }

	public void Animate(bool value) { }

	private void Awake() { }

	public void ForceAppsOpen() { }

	public Application GetApplication(int index) { }

	public void Init() { }

	private void InitApplicationsStatesIfNeeded() { }

	private void InitCamera() { }

	private void OnApplicationEndAnimation(bool value) { }

	private void OnCancelRecording() { }

	private void OnDestroy() { }

	private void OnStartRecording() { }

	private void OnStopRecording() { }

	private void SaveApplicationsStates(ApplicationsStateList stateList) { }

	public override void SetDownloaded(Application application) { }

}

