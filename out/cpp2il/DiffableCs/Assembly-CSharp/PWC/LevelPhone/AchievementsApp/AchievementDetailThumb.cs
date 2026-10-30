namespace PWC.LevelPhone.AchievementsApp;

public class AchievementDetailThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public static Action<PointerEventData> OnAchievementDetailClickAction; //Field offset: 0x0
	[SerializeField]
	private TextMeshProUGUI _numberText; //Field offset: 0x20
	[SerializeField]
	private TextMeshProUGUI _nameText; //Field offset: 0x28
	[SerializeField]
	private Image _questionMarkImage; //Field offset: 0x30
	[SerializeField]
	private Image _completedBadge; //Field offset: 0x38
	[SerializeField]
	private Image _prizeIcon; //Field offset: 0x40
	[SerializeField]
	private TextMeshProUGUI _coinAmount; //Field offset: 0x48
	[SerializeField]
	private Image _background; //Field offset: 0x50
	[SerializeField]
	private SerializableDictionaryBase<PrizeType, Sprite> _prizesSprites; //Field offset: 0x58
	private AchievementData _achievementData; //Field offset: 0x60
	private LevelType _levelType; //Field offset: 0x68
	private Sprite _unsolvedBackground; //Field offset: 0x70
	private Sprite _solvedBackground; //Field offset: 0x78
	private bool _isCompleted; //Field offset: 0x80

	public AchievementDetailThumb() { }

	public void Animate(bool value, float delay = 0) { }

	private void Awake() { }

	private bool IsAchievementCompleted() { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnSecretSolved(LevelType type, SecretData data) { }

	public void SetData(AchievementData achievementData, LevelType levelType, int achievementNumber, Sprite solvedBackground) { }

	private void UpdatePrizeIcon() { }

	public void UpdateVisualState(bool isCompleted) { }

}

