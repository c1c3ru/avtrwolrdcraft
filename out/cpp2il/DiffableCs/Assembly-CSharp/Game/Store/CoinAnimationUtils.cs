namespace Game.Store;

public static class CoinAnimationUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public TextMeshProUGUI currencyViewerText; //Field offset: 0x10
		public Action onComplete; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <AnimateCoinCount>b__0(float value) { }

		internal void <AnimateCoinCount>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public CanvasGroup canvasGroup; //Field offset: 0x10
		public GameObject floatingTextGO; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <ShowFloatingText>b__0() { }

		internal void <ShowFloatingText>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public float idleMoveAmount; //Field offset: 0x10
		public float idleAnimationDuration; //Field offset: 0x14

		public <>c__DisplayClass6_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_1
	{
		public GameObject animatedCoin; //Field offset: 0x10
		public <>c__DisplayClass6_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass6_1() { }

		internal void <SpawnCoinsAndMoveToRandomPositions>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public bool isCoinCountAnimated; //Field offset: 0x10
		public GameObject parentGameObject; //Field offset: 0x18
		public TextMeshProUGUI currencyViewerText; //Field offset: 0x20
		public int coinsEarned; //Field offset: 0x28
		public Action onComplete; //Field offset: 0x30
		public Action <>9__1; //Field offset: 0x38

		public <>c__DisplayClass9_0() { }

		internal void <MoveAllCoinsToEnd>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_1
	{
		public GameObject animatedCoin; //Field offset: 0x10
		public <>c__DisplayClass9_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass9_1() { }

		internal void <MoveAllCoinsToEnd>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <MoveAllCoinsToEnd>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject parentGameObject; //Field offset: 0x20
		public TextMeshProUGUI currencyViewerText; //Field offset: 0x28
		public int coinsEarned; //Field offset: 0x30
		public Action onComplete; //Field offset: 0x38
		private <>c__DisplayClass9_0 <>8__1; //Field offset: 0x40
		public List<GameObject> spawnedCoins; //Field offset: 0x48
		private Vector3 <targetWorldPosition>5__2; //Field offset: 0x50
		private int <count>5__3; //Field offset: 0x5C
		private int <i>5__4; //Field offset: 0x60

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <MoveAllCoinsToEnd>d__9(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <SpawnCoinsAndMoveToRandomPositions>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float idleMoveAmount; //Field offset: 0x20
		public float idleAnimationDuration; //Field offset: 0x24
		public GameObject animationGameObjectInstanse; //Field offset: 0x28
		public int spawnedCoinAmount; //Field offset: 0x30
		private <>c__DisplayClass6_0 <>8__1; //Field offset: 0x38
		public GameObject coinPrefab; //Field offset: 0x40
		public Vector3 spawnPosition; //Field offset: 0x48
		public Transform spawnedCoinsParent; //Field offset: 0x58
		public float spawnRadius; //Field offset: 0x60
		public float minSpawnDistance; //Field offset: 0x64
		public List<GameObject> spawnedCoins; //Field offset: 0x68
		public Action OnEndAction; //Field offset: 0x70
		private List<Vector3> <finalRandomPositions>5__2; //Field offset: 0x78
		private int <i>5__3; //Field offset: 0x80

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <SpawnCoinsAndMoveToRandomPositions>d__6(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const int MAX_SPAWN_ATTEMPTS = 50; //Field offset: 0x0
	private const float ANIMATION_DURATION = 1; //Field offset: 0x0
	private const float INITIAL_MOVEMENT_DURATION = 0,3; //Field offset: 0x0
	private const float FLOATING_TEXT_DURATION = 3; //Field offset: 0x0
	public const int CHANNEL_COINS = 0; //Field offset: 0x0
	public const int CHANNEL_BALANCE = 1; //Field offset: 0x0

	private static void AnimateCoinCount(GameObject gameObject, TextMeshProUGUI currencyViewerText, int amountToAdd, Action onComplete) { }

	private static Vector3 FindValidRandomPosition(Vector3 initialSpawnPosition, float spawnRadius, float minSpawnDistance, List<Vector3> finalRandomPositions) { }

	public static void ForceDestroyCoins(Transform spawnedCoinsParent) { }

	[IteratorStateMachine(typeof(<MoveAllCoinsToEnd>d__9))]
	public static IEnumerator MoveAllCoinsToEnd(GameObject parentGameObject, List<GameObject> spawnedCoins, TextMeshProUGUI currencyViewerText, int coinsEarned, Action onComplete = null) { }

	public static void ShowFloatingText(Canvas canvas, GameObject floatingTextGO, int floatingTextCoinAmount, Vector3 coinPosition, float floatingTextOffset = 0,8, bool isReletiveToCoins = false) { }

	[IteratorStateMachine(typeof(<SpawnCoinsAndMoveToRandomPositions>d__6))]
	public static IEnumerator SpawnCoinsAndMoveToRandomPositions(Vector3 spawnPosition, GameObject coinPrefab, List<GameObject> spawnedCoins, Transform spawnedCoinsParent, GameObject animationGameObjectInstanse, int spawnedCoinAmount, float idleMoveAmount = 1, float idleAnimationDuration = 1, float spawnRadius = 1, float minSpawnDistance = 1, Action OnEndAction = null) { }

	private static void StartIdleAnimation(GameObject coin, float idleMoveAmount, float idleAminationDuration) { }

}

