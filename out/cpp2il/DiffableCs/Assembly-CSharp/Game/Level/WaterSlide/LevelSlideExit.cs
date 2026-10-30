namespace Game.Level.WaterSlide;

public class LevelSlideExit : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SlideItems>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSlideExit <>4__this; //Field offset: 0x20
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
		public <SlideItems>d__7(int <>1__state) { }

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
	private LevelType _levelType; //Field offset: 0x20
	[SerializeField]
	private LevelSlideArea _slideDropArea; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private Transform _startPoint; //Field offset: 0x38

	public LevelSlideExit() { }

	private void Awake() { }

	private void InitItem(PDPrefab pdPrefab) { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	[IteratorStateMachine(typeof(<SlideItems>d__7))]
	private IEnumerator SlideItems() { }

}

