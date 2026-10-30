namespace Game.Level.WaterSlide;

public class LevelSlideItemsSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SlideItems>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSlideItemsSpawner <>4__this; //Field offset: 0x20
		private List<PDPrefab> <PDPrefabs>5__2; //Field offset: 0x28
		private int <i>5__3; //Field offset: 0x30

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
		public <SlideItems>d__9(int <>1__state) { }

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

	[SerializeField]
	private LevelDropArea[] _slideDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelSlideSpineHandler[] _sliderHandler; //Field offset: 0x28
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x30
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x38
	private LevelItem _slideItem; //Field offset: 0x40
	public Action<LevelItem> OnFirstItemSpawnAction; //Field offset: 0x48

	public LevelSlideItemsSpawner() { }

	[CompilerGenerated]
	private void <InitItem>b__10_0() { }

	private void Awake() { }

	private void InitItem(PDPrefab pdPrefab, int index) { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	[IteratorStateMachine(typeof(<SlideItems>d__9))]
	private IEnumerator SlideItems() { }

}

