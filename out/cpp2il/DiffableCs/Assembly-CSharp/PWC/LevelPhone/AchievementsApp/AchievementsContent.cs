namespace PWC.LevelPhone.AchievementsApp;

public class AchievementsContent : ApplicationContentBase
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<HuntData, Int64> <>9__22_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal long <CreateHuntThumbs>b__22_0(HuntData hunt) { }

	}

	public const float ANIMATION_TIME = 0,1; //Field offset: 0x0
	[SerializeField]
	private AchievementsHuntThumb _huntThumbPrefab; //Field offset: 0x38
	[SerializeField]
	private GameObject _huntsPage; //Field offset: 0x40
	[SerializeField]
	private Transform _huntsContainer; //Field offset: 0x48
	[SerializeField]
	private AchievementDetailsPage _detailsPagePrefab; //Field offset: 0x50
	[SerializeField]
	private Transform _detailsPageParent; //Field offset: 0x58
	[SerializeField]
	private Transform _phoneTransform; //Field offset: 0x60
	private bool _didSetupFirstTimeInScene; //Field offset: 0x68
	private bool _isShowingDetails; //Field offset: 0x69
	private Dictionary<String, AchievementsHuntThumb> _huntThumbs; //Field offset: 0x70
	private AchievementDetailsPage _currentDetailsPage; //Field offset: 0x78

	public AchievementsHuntThumb HuntThumbPrefab
	{
		 get { } //Length: 8
	}

	public AchievementsContent() { }

	protected virtual void Awake() { }

	private void CloseDetailsPage() { }

	private void CreateHuntThumbs() { }

	public AchievementsHuntThumb get_HuntThumbPrefab() { }

	protected virtual void OnApplicationClick(Application application) { }

	protected virtual void OnApplicationEndAnimation(bool value) { }

	protected virtual void OnBackButtonClick() { }

	protected virtual void OnDestroy() { }

	private void OnHuntThumbClick(HuntData huntData) { }

	private void OnLevelPostInit() { }

	private void OnPhoneEndAnimation(bool value) { }

	protected virtual void OnSetActive(bool value) { }

	public void SetAutoOpenAchievementsApplication(string guid) { }

}

