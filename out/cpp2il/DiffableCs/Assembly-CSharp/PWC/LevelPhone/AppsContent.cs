namespace PWC.LevelPhone;

public class AppsContent : ApplicationContentBase, IApplicationsOwner
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public bool value; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal void <OnApplicationEndAnimation>b__0(Application application) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public ApplicationsStateList stateList; //Field offset: 0x10
		public AppsContent <>4__this; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <InitApplicationsStatesIfNeeded>b__0(Application application) { }

		internal void <InitApplicationsStatesIfNeeded>b__3(Application application) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_1
	{
		public string key; //Field offset: 0x10

		public <>c__DisplayClass6_1() { }

		internal bool <InitApplicationsStatesIfNeeded>b__1(ApplicationState downloadState) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_2
	{
		public ApplicationsStateList newStateList; //Field offset: 0x10

		public <>c__DisplayClass6_2() { }

		internal void <InitApplicationsStatesIfNeeded>b__2(Application application) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string key; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <SetDownloaded>b__0(ApplicationState downloadState) { }

	}

	private const string APPLICATIONS_STATE_LIST_KEY = "AppsContent_ApplicationsStatesList"; //Field offset: 0x0
	[SerializeField]
	private List<Application> _applications; //Field offset: 0x38
	private bool _didAnimateApplicationsOnce; //Field offset: 0x40
	private bool _isInitedApplications; //Field offset: 0x41

	public AppsContent() { }

	[CompilerGenerated]
	private void <OnApplicationClick>b__9_0(Application application) { }

	[CompilerGenerated]
	private void <OnApplicationClick>b__9_1() { }

	[CompilerGenerated]
	private void <OnBackButtonClick>b__11_0(Application application) { }

	[CompilerGenerated]
	private void <OnBackButtonClick>b__11_1() { }

	public List<Application> GetApplications() { }

	private void InitApplicationsStatesIfNeeded() { }

	protected virtual void OnApplicationClick(Application application) { }

	protected virtual void OnApplicationEndAnimation(bool value) { }

	protected virtual void OnBackButtonClick() { }

	protected virtual void OnSetActive(bool value) { }

	private void SaveApplicationsStates(ApplicationsStateList stateList) { }

	public override void SetDownloaded(Application application) { }

}

