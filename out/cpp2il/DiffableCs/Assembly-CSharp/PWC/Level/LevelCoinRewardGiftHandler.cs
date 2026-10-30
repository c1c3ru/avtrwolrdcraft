namespace PWC.Level;

[RequireComponent(typeof(LevelItem))]
public class LevelCoinRewardGiftHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IPointerClickHandler, IEventSystemHandler, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__12_0; //Field offset: 0x8
		public static Action <>9__14_2; //Field offset: 0x10
		public static Action <>9__14_1; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <EnsureOnReadyPostLoad>b__12_0() { }

		internal void <OnPointerClick>b__14_1() { }

		internal void <OnPointerClick>b__14_2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public LevelCoinRewardGiftHandler <>4__this; //Field offset: 0x10
		public Dictionary<String, String> ids; //Field offset: 0x18

		public <>c__DisplayClass14_0() { }

		internal void <OnPointerClick>b__0(List<AWAAchievementWorth> achivementsList) { }

	}

	[SerializeField]
	private string _achievementGuid; //Field offset: 0x20
	[SerializeField]
	private LevelTransformableCustomItemHandler _transformableItemHandler; //Field offset: 0x28
	private CoinAnimationManager _coinManager; //Field offset: 0x30
	private LevelCanvasUICurrencyViewerAnimator _coinsViewerAnimator; //Field offset: 0x38
	private int _coins; //Field offset: 0x40
	private Vector3 _coinsStartPointOffset; //Field offset: 0x44

	public LevelCoinRewardGiftHandler() { }

	private void AddCoins(int coins, Action onComplete) { }

	private void AddCoinsToBank(int coins, Action onComplete) { }

	private void Awake() { }

	private void DestroySequence() { }

	private void EnsureCoinManagerForAnimation() { }

	private void EnsureOnReadyPostLoad() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnSpawnDuringGameplay() { }

	public void SetCoins(int coins) { }

	public void SetGuid(string achievementGuid) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

