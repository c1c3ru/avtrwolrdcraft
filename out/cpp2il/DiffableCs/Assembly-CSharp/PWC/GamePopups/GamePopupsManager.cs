namespace PWC.GamePopups;

public class GamePopupsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public Color color; //Field offset: 0x10
		public GamePopupsManager <>4__this; //Field offset: 0x20
		public bool value; //Field offset: 0x28

		public <>c__DisplayClass17_0() { }

		internal void <ClickBlockerSetActive>b__0(float alphaValue) { }

		internal void <ClickBlockerSetActive>b__1() { }

	}

	private class BWYWPopupData
	{
		public string title; //Field offset: 0x10
		public string description; //Field offset: 0x18
		public int xp; //Field offset: 0x20
		public Sprite sprite; //Field offset: 0x28
		public int tasksDone; //Field offset: 0x30
		public int target; //Field offset: 0x34
		public float duration; //Field offset: 0x38

		public BWYWPopupData() { }

	}

	[CompilerGenerated]
	private static GamePopupsManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private GamePopup _gamePopupPrefab; //Field offset: 0x20
	[SerializeField]
	private BWYWTimedGamePopup _BWYWNotification; //Field offset: 0x28
	[SerializeField]
	private Image _clickBlocker; //Field offset: 0x30
	private GamePopupType _currentPopupType; //Field offset: 0x38
	private Action _currentOnConfirmAction; //Field offset: 0x40
	private BWYWTimedGamePopup _currentActiveNotification; //Field offset: 0x48
	private List<BWYWPopupData> _popupQueue; //Field offset: 0x50
	private string _currentPopupTitle; //Field offset: 0x58
	private bool _isPromotionPopupDisabled; //Field offset: 0x60

	public private static GamePopupsManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public bool IsPromotionPopupDisabled
	{
		 get { } //Length: 8
	}

	public GamePopupsManager() { }

	[CompilerGenerated]
	private bool <TryShowNextBWYWNotificationIfExist>b__21_0(BWYWPopupData x) { }

	[CompilerGenerated]
	private bool <TryShowNextBWYWNotificationIfExist>b__21_1(BWYWPopupData x) { }

	private void Awake() { }

	private void ClickBlockerSetActive(bool value) { }

	public void DisablePromotionPopUps() { }

	public void EnablePromotionPopUps() { }

	[CompilerGenerated]
	public static GamePopupsManager get_Instance() { }

	public bool get_IsPromotionPopupDisabled() { }

	private GameObject GetPrefabByName(string prefabName) { }

	private Sprite GetPromotionSpriteByName(string spriteName) { }

	private Sprite GetSpriteByName(string spriteName) { }

	private void OnButtonPress(bool value) { }

	private void OnDestroy() { }

	private void OnNotificationEnd() { }

	public BWYWTimedGamePopup PresentBWYWNotificationPopup(string title, string description, int xp, Sprite sprite, int tasksDone, int target, float duration) { }

	public GamePopup PresentPopup(GamePopupType popupType, Action onConfirmAction, bool isPrefab = false, bool hasCustomGamePopup = false) { }

	public void PresentPopup_Promotion(string name, Transform transform, bool isBundle, Action onConfirmAction) { }

	public void PresentPopup_RestWithCustomSprite(Sprite sprite, float spriteScale, Action onConfirmAction) { }

	private GamePopup PresentPopupImplement(GamePopupType popupType, GameObject CustomPopup = null) { }

	private BWYWTimedGamePopup PresentTimedPopupImplement() { }

	[CompilerGenerated]
	private static void set_Instance(GamePopupsManager value) { }

	public void StopBWYWPopups() { }

	public BWYWTimedGamePopup TryShowNextBWYWNotificationIfExist(out int taskProgress, out int target) { }

}

