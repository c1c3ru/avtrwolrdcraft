namespace PWC.Level;

public class LevelCanvasUICurrencyViewerAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public Vector2 localPosition; //Field offset: 0x10
		public RectTransform rectTransform; //Field offset: 0x18
		public LevelCanvasUICurrencyViewerAnimator <>4__this; //Field offset: 0x20
		public bool value; //Field offset: 0x28
		public bool isKittyBank; //Field offset: 0x29

		public <>c__DisplayClass17_0() { }

		internal void <Animate>b__0(float localYPosition) { }

		internal void <Animate>b__1() { }

	}

	public static Action OnAnimationStart; //Field offset: 0x0
	public static Action OnAnimationEnd; //Field offset: 0x8
	[CompilerGenerated]
	private static LevelCanvasUICurrencyViewerAnimator <Instance>k__BackingField; //Field offset: 0x10
	[SerializeField]
	private GameObject _kittyBank; //Field offset: 0x20
	[SerializeField]
	private GameObject _UserBalance; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _userBalanceText; //Field offset: 0x30
	[SerializeField]
	private GameObject _coinAnimationManagerPrefab; //Field offset: 0x38
	private int _activeGiftAnimations; //Field offset: 0x40
	private CoinAnimationManager _spawnedCoinManager; //Field offset: 0x48
	private bool _wasSpawnedByGift; //Field offset: 0x50
	private int _tweenId; //Field offset: 0x54
	private bool _isMoving; //Field offset: 0x58

	public private static LevelCanvasUICurrencyViewerAnimator Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public LevelCanvasUICurrencyViewerAnimator() { }

	public void Animate(bool value, bool isKittyBank) { }

	private void Awake() { }

	private void CleanupSpawnedCoinManager() { }

	public void DecrementActiveAnimations() { }

	public CoinAnimationManager EnsureCoinManagerExists() { }

	[CompilerGenerated]
	public static LevelCanvasUICurrencyViewerAnimator get_Instance() { }

	public void IncrementActiveAnimations() { }

	public void Init(int coins) { }

	private void InitCoinManager() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(LevelCanvasUICurrencyViewerAnimator value) { }

}

