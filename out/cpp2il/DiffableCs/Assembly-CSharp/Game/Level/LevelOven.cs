namespace Game.Level;

public class LevelOven : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCookableItemHandler> <>9__13_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <TryCook>b__13_0(LevelCookableItemHandler x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public bool value; //Field offset: 0x10

		public <>c__DisplayClass15_0() { }

		internal void <ParticleSystemsSetActive>b__0(ParticleSystem particleSystem) { }

	}

	[CompilerGenerated]
	private sealed class <Cook>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelOven <>4__this; //Field offset: 0x20
		public LevelCookableItemHandler[] cookables; //Field offset: 0x28

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
		public <Cook>d__14(int <>1__state) { }

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
	private LevelNewSimpleTransparentContainer _transparentContainer; //Field offset: 0x20
	[SerializeField]
	private LevelLight _insideLight; //Field offset: 0x28
	[SerializeField]
	private List<ParticleSystem> _particleSystems; //Field offset: 0x30
	[SerializeField]
	private string _endCookingSound; //Field offset: 0x38
	public UnityEvent onTurnOn; //Field offset: 0x40
	public UnityEvent onTurnOff; //Field offset: 0x48
	private Coroutine _cookCoroutine; //Field offset: 0x50
	private bool _isOn; //Field offset: 0x58

	public LevelOven() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<Cook>d__14))]
	private IEnumerator Cook(LevelCookableItemHandler[] cookables) { }

	private void OnDestroy() { }

	public void OnDoorStateChange(List<LevelItem> items, bool isOpen) { }

	private void OnLevelPostInit() { }

	private void ParticleSystemsSetActive(bool value) { }

	private void StopCook() { }

	private void TryCook() { }

}

