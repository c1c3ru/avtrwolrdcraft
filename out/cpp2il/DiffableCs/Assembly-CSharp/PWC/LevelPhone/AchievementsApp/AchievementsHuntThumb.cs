namespace PWC.LevelPhone.AchievementsApp;

public class AchievementsHuntThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public Action onCompleteAction; //Field offset: 0x10

		public <>c__DisplayClass15_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action<HuntData> OnLevelThumbClickAction; //Field offset: 0x0
	[SerializeField]
	private Image _background; //Field offset: 0x20
	[SerializeField]
	private Image _trophyIcon; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _huntText; //Field offset: 0x30
	[SerializeField]
	private TextMeshProUGUI _progressText; //Field offset: 0x38
	private int _tweenID; //Field offset: 0x40
	private HuntData _huntData; //Field offset: 0x48

	public static event Action<HuntData> OnLevelThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public HuntData HuntData
	{
		 get { } //Length: 8
	}

	public AchievementsHuntThumb() { }

	[CompilerGenerated]
	public static void add_OnLevelThumbClickAction(Action<HuntData> value) { }

	public void Animate(bool value, Action onCompleteAction = null) { }

	private void Awake() { }

	public void ForceClick() { }

	public HuntData get_HuntData() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnResetButtonClick(int index) { }

	private void OnSecretSolved(LevelType type, SecretData data) { }

	[CompilerGenerated]
	public static void remove_OnLevelThumbClickAction(Action<HuntData> value) { }

	public void SetData(HuntData huntData) { }

	private void UpdateProgress(int justSolvedSecretID = -1) { }

}

