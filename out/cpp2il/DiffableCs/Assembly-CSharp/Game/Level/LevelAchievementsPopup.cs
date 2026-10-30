namespace Game.Level;

public class LevelAchievementsPopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public LevelAchievementsPopup <>4__this; //Field offset: 0x10
		public string achievementName; //Field offset: 0x18
		public int progression; //Field offset: 0x20
		public int total; //Field offset: 0x24
		public Sprite icon; //Field offset: 0x28
		public bool isLastAchievement; //Field offset: 0x30
		public Action <>9__1; //Field offset: 0x38

		public <>c__DisplayClass24_0() { }

		internal void <ShowPopup>b__0() { }

		internal void <ShowPopup>b__1() { }

	}

	private class AchievementPopupData
	{
		public HuntData data; //Field offset: 0x10
		public string name; //Field offset: 0x18
		public int totalSolvedUntilNow; //Field offset: 0x20

		public AchievementPopupData() { }

	}

	private const float SCALE_ANIMATION_DURATION_DIVISOR = 5; //Field offset: 0x0
	private const float CLOSE_POSITION_Y = 700; //Field offset: 0x0
	private const float OPEN_POSITION_Y = 480; //Field offset: 0x0
	[SerializeField]
	private float _animationDuration; //Field offset: 0x20
	[SerializeField]
	private float _popupDuration; //Field offset: 0x24
	[SerializeField]
	private Image _achievementIcon; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _achievementName; //Field offset: 0x30
	[SerializeField]
	private TextMeshProUGUI _achievementProgression; //Field offset: 0x38
	[FormerlySerializedAs("_achievementbackground")]
	[SerializeField]
	private Image _achievementBackground; //Field offset: 0x40
	[SerializeField]
	private Sprite _defaultBackground; //Field offset: 0x48
	[SerializeField]
	private Sprite _finalAchievementBackground; //Field offset: 0x50
	[SerializeField]
	private GameObject _particles; //Field offset: 0x58
	[SerializeField]
	private LevelBoomboxAnniversaryHandler _levelBoomboxAnniversaryHandler; //Field offset: 0x60
	private Queue<AchievementPopupData> _queue; //Field offset: 0x68
	private bool _isShowingPopup; //Field offset: 0x70
	private Camera _mainCamera; //Field offset: 0x78
	private List<String> _listOfCelebrationAnimations; //Field offset: 0x80

	public LevelAchievementsPopup() { }

	private void AddParticles() { }

	private void Awake() { }

	private void CallAnimations() { }

	private void ClosePopup() { }

	private int CountCompleted(HuntData hunt, int justSolvedSecretID = -1) { }

	private void CreateParticle(Vector3 localPosition) { }

	private void LastAchievementCelebration() { }

	private void OnAchievementCompleteAction(HuntData hunt, AchievementData achievementData) { }

	private void OnCloseFinish() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OpenPopup() { }

	private void ShowPopup(string achievementName, int progression, int total, Sprite icon) { }

	private void StopAnimations() { }

	private void TryShowPopup() { }

}

