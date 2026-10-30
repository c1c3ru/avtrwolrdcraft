namespace Game.Store;

public class SubscriptionCoinAnimation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public SubscriptionCoinAnimation <>4__this; //Field offset: 0x10
		public List<GameObject> spawnedCoins; //Field offset: 0x18
		public Action onComplete; //Field offset: 0x20

		public <>c__DisplayClass25_0() { }

		internal void <PlayCoinAnimation>b__0() { }

	}

	[CompilerGenerated]
	private static SubscriptionCoinAnimation <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private Transform _window; //Field offset: 0x20
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
	[Header("Coin Spawn Settings")]
	[SerializeField]
	private float _spawnRadius; //Field offset: 0x50
	[SerializeField]
	private float _minSpawnDistance; //Field offset: 0x54
	[SerializeField]
	private float _idleMoveAmount; //Field offset: 0x58
	[SerializeField]
	private float _idleAnimationDuration; //Field offset: 0x5C
	[SerializeField]
	private float _floatingTextOffset; //Field offset: 0x60
	[SerializeField]
	private int _spawnedCoinAmount; //Field offset: 0x64
	private Canvas _canvas; //Field offset: 0x68
	private int _currentCurrencyPackCoinAmount; //Field offset: 0x70
	private int _coinAmountBeforePurchase; //Field offset: 0x74

	public private static SubscriptionCoinAnimation Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public SubscriptionCoinAnimation() { }

	private void Awake() { }

	[CompilerGenerated]
	public static SubscriptionCoinAnimation get_Instance() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void PlayCoinAnimation(Action onComplete = null) { }

	[CompilerGenerated]
	private static void set_Instance(SubscriptionCoinAnimation value) { }

	private void SetCanvas() { }

	public void StartAnimation(int coinAmount, Action onComplete = null) { }

	private void UpdateCoinAmountBeforePurchase() { }

}

