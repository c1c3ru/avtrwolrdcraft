namespace StarsPass;

public static class StarsAnimationUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public StarsPassBarManager starsBarManager; //Field offset: 0x10
		public bool shouldUpdateBarAmount; //Field offset: 0x18
		public Action onComplete; //Field offset: 0x20
		public Action<GameObject> releaseStar; //Field offset: 0x28
		public Action <>9__1; //Field offset: 0x30

		public <>c__DisplayClass7_0() { }

		internal void <MoveAllStarsToStarsPassBar>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_1
	{
		public GameObject animatedStar; //Field offset: 0x10
		public bool isLastStar; //Field offset: 0x18
		public <>c__DisplayClass7_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass7_1() { }

		internal void <MoveAllStarsToStarsPassBar>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public CanvasGroup canvasGroup; //Field offset: 0x10
		public GameObject floatingTextGO; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <ShowFloatingStarsPassText>b__0() { }

		internal void <ShowFloatingStarsPassText>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <MoveAllStarsToStarsPassBar>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StarsPassBarManager starsBarManager; //Field offset: 0x20
		public Action onComplete; //Field offset: 0x28
		public Action<GameObject> releaseStar; //Field offset: 0x30
		public RectTransform goToRectTransform; //Field offset: 0x38
		public List<GameObject> spawnedStars; //Field offset: 0x40
		private <>c__DisplayClass7_0 <>8__1; //Field offset: 0x48
		private Vector3 <targetWorldPosition>5__2; //Field offset: 0x50
		private int <i>5__3; //Field offset: 0x5C

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
		public <MoveAllStarsToStarsPassBar>d__7(int <>1__state) { }

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
	private sealed class <SpawnStarsAndMoveToRandomPositions>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Func<Vector3, GameObject> acquireStar; //Field offset: 0x20
		public Vector3 spawnPosition; //Field offset: 0x28
		public float spawnRadius; //Field offset: 0x34
		public float minSpawnDistance; //Field offset: 0x38
		public List<GameObject> spawnedStars; //Field offset: 0x40
		public int spawnedStarsAmount; //Field offset: 0x48
		public Action onEndAction; //Field offset: 0x50
		private List<Vector3> <finalRandomPositions>5__2; //Field offset: 0x58
		private int <i>5__3; //Field offset: 0x60

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
		public <SpawnStarsAndMoveToRandomPositions>d__5(int <>1__state) { }

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

	private const float ANIMATION_DURATION = 1; //Field offset: 0x0
	private const float INITIAL_MOVEMENT_DURATION = 0,3; //Field offset: 0x0
	private const float FLOATING_TEXT_DURATION = 3; //Field offset: 0x0
	private const int SOUND_CHANNEL_STARS_BALANCE = 2; //Field offset: 0x0
	private const float DURATION_BETWEEN_STARS = 0,05; //Field offset: 0x0

	private static Vector3 FindValidRandomPosition(Vector3 initialSpawnPosition, float spawnRadius, float minSpawnDistance, List<Vector3> finalRandomPositions) { }

	[IteratorStateMachine(typeof(<MoveAllStarsToStarsPassBar>d__7))]
	public static IEnumerator MoveAllStarsToStarsPassBar(StarsPassBarManager starsBarManager, List<GameObject> spawnedStars, RectTransform goToRectTransform, Action<GameObject> releaseStar, Action onComplete = null) { }

	public static void ShowFloatingStarsPassText(Canvas canvas, GameObject floatingTextGO, int floatingTextStarAmount, Vector3 starPosition, float floatingTextOffset = 0,8, bool isRelativeToStars = false) { }

	[IteratorStateMachine(typeof(<SpawnStarsAndMoveToRandomPositions>d__5))]
	public static IEnumerator SpawnStarsAndMoveToRandomPositions(Vector3 spawnPosition, Func<Vector3, GameObject> acquireStar, List<GameObject> spawnedStars, int spawnedStarsAmount, float spawnRadius = 1, float minSpawnDistance = 1, Action onEndAction = null) { }

}

