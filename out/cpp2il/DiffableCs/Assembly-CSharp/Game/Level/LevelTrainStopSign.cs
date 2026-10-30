namespace Game.Level;

public class LevelTrainStopSign : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__13_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnPointerClick>b__13_0() { }

	}

	[CompilerGenerated]
	private sealed class <FlickerLight>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTrainStopSign <>4__this; //Field offset: 0x20

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
		public <FlickerLight>d__11(int <>1__state) { }

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
	private sealed class <TurnOffLightWhenNeeded>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelTrainStopSign <>4__this; //Field offset: 0x20

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
		public <TurnOffLightWhenNeeded>d__12(int <>1__state) { }

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
	private static Action<Boolean, Action> OnTrainSignClickAction; //Field offset: 0x0
	[SerializeField]
	private string _signClickSound; //Field offset: 0x20
	[SerializeField]
	private LevelLight _levelLight; //Field offset: 0x28
	[SerializeField]
	private LevelTrain _train; //Field offset: 0x30
	private bool _needFlicker; //Field offset: 0x38

	public static event Action<Boolean, Action> OnTrainSignClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelTrainStopSign() { }

	[CompilerGenerated]
	private bool <TurnOffLightWhenNeeded>b__12_0() { }

	[CompilerGenerated]
	public static void add_OnTrainSignClickAction(Action<Boolean, Action> value) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<FlickerLight>d__11))]
	private IEnumerator FlickerLight() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnTrainSignClickAction(Action<Boolean, Action> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void StartFlicker() { }

	[IteratorStateMachine(typeof(<TurnOffLightWhenNeeded>d__12))]
	private IEnumerator TurnOffLightWhenNeeded() { }

}

