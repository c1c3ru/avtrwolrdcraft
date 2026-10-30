namespace PWC.LevelPhone;

public class AchievementDetailsPage : MonoBehaviour
{
	public static Action<Int32> OnResetButtonClickAction; //Field offset: 0x0
	public static Action<String> OnGoToLevelAction; //Field offset: 0x8
	public static Action OnGoToLevelFailed; //Field offset: 0x10
	[SerializeField]
	private TextMeshProUGUI _levelTitle; //Field offset: 0x20
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x28
	[SerializeField]
	private Transform _achievementsList; //Field offset: 0x30
	[SerializeField]
	private AchievementDetailThumb _achievementDetailPrefab; //Field offset: 0x38
	[SerializeField]
	private TextMeshProUGUI _countText; //Field offset: 0x40
	[SerializeField]
	private GameObject _tooltipPrefab; //Field offset: 0x48
	[SerializeField]
	private Image _bigPrizeImage; //Field offset: 0x50
	[SerializeField]
	private Image _footerBar; //Field offset: 0x58
	[SerializeField]
	private Sprite _completedFooterBarSprite; //Field offset: 0x60
	[SerializeField]
	private Sprite _generalContentIcon; //Field offset: 0x68
	[SerializeField]
	private Button _goToLevelButton; //Field offset: 0x70
	[SerializeField]
	private Button _resetButtonPrefab; //Field offset: 0x78
	private List<AchievementDetailThumb> _achievementThumbs; //Field offset: 0x80
	private HuntData _currentHuntData; //Field offset: 0x88
	private StoreTweenToolipHandle _tooltipHandle; //Field offset: 0x90
	private GameObject _tooltip; //Field offset: 0x98
	private Transform _phoneTransform; //Field offset: 0xA0
	private Button _resetButtonInstance; //Field offset: 0xA8

	public AchievementDetailsPage() { }

	[CompilerGenerated]
	private void <Show>b__24_0() { }

	[CompilerGenerated]
	private void <UpdateResetButton>b__26_0() { }

	private void Awake() { }

	private int CountCompleted() { }

	public void DisplayResetPopUp() { }

	private void GoToHuntLevel() { }

	private void HideTooltip() { }

	private void HideTooltip(bool value) { }

	private void OnBackButtonClick() { }

	private void OnDestroy() { }

	private void OnSecretSolved(LevelType type, SecretData data) { }

	private void ResetHunt() { }

	public void Show(HuntData huntData, Transform phoneTransform) { }

	private void ShowTooltip(PointerEventData eventData) { }

	private void UpdateCompletionText() { }

	private void UpdateResetButton(int completedCount) { }

}

