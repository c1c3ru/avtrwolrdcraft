namespace Game.Store;

public class CoinAnimationManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public CoinAnimationManager <>4__this; //Field offset: 0x10
		public bool showDefaultNumberOfCoins; //Field offset: 0x18
		public Action onComplete; //Field offset: 0x20

		public <>c__DisplayClass28_0() { }

		internal void <ShowSuccessMessage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public CoinAnimationManager <>4__this; //Field offset: 0x10
		public List<GameObject> spawnedCoins; //Field offset: 0x18
		public int coinsAmount; //Field offset: 0x20
		public Action onComplete; //Field offset: 0x28

		public <>c__DisplayClass29_0() { }

		internal void <PlayCoinAnimation>b__0() { }

	}

	internal enum CoinManagerContext
	{
		GiftHunt = 0,
		StorePurchase = 1,
	}

	[CompilerGenerated]
	private static CoinAnimationManager <GiftHuntInstance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static CoinAnimationManager <StorePurchaseInstance>k__BackingField; //Field offset: 0x8
	[SerializeField]
	private Canvas _canvas; //Field offset: 0x20
	[SerializeField]
	private RectTransform _coinsRectTransform; //Field offset: 0x28
	[SerializeField]
	private GameObject _coinPrefab; //Field offset: 0x30
	[SerializeField]
	private GameObject _floatingTextGO; //Field offset: 0x38
	[SerializeField]
	private TextMeshProUGUI _currencyViewerText; //Field offset: 0x40
	[SerializeField]
	private Transform _spawnedCoinsParent; //Field offset: 0x48
	[SerializeField]
	private CoinManagerContext _context; //Field offset: 0x50
	[Header("Coin Spawn Settings")]
	[SerializeField]
	private float _spawnRadius; //Field offset: 0x54
	[SerializeField]
	private float _minSpawnDistance; //Field offset: 0x58
	[SerializeField]
	private float _idleMoveAmount; //Field offset: 0x5C
	[SerializeField]
	private float _idleAnimationDuration; //Field offset: 0x60
	[SerializeField]
	private int _spawnedCoinAmount; //Field offset: 0x64
	private int _currentCurrencyPackCoinAmount; //Field offset: 0x68

	public TextMeshProUGUI CurrencyViewerText
	{
		 get { } //Length: 8
	}

	public GameObject FloatingTextGO
	{
		 get { } //Length: 8
	}

	public private static CoinAnimationManager GiftHuntInstance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private static CoinAnimationManager StorePurchaseInstance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public CoinAnimationManager() { }

	private void Awake() { }

	public TextMeshProUGUI get_CurrencyViewerText() { }

	public GameObject get_FloatingTextGO() { }

	[CompilerGenerated]
	public static CoinAnimationManager get_GiftHuntInstance() { }

	[CompilerGenerated]
	public static CoinAnimationManager get_StorePurchaseInstance() { }

	private void OnDestroy() { }

	public void PlayCoinAnimation(Vector3 startPosition, int coinsAmount, bool isRelativeToCoins = false, bool showDefaultNumberOfCoins = true, Action onComplete = null) { }

	[CompilerGenerated]
	private static void set_GiftHuntInstance(CoinAnimationManager value) { }

	[CompilerGenerated]
	private static void set_StorePurchaseInstance(CoinAnimationManager value) { }

	public void SetCurrencyViewerText(TextMeshProUGUI currencyViewerText) { }

	public void ShowSuccessMessage(int coinAmount = 0, bool showDefaultNumberOfCoins = true, Action onComplete = null) { }

}

