namespace Game.Level.Arcade;

public class LevelSlushyDispenser : LevelDrinkDispenser
{
	[CompilerGenerated]
	private sealed class <TurnOffDispenser>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float seconds; //Field offset: 0x20
		public LevelSlushyDispenser <>4__this; //Field offset: 0x28

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
		public <TurnOffDispenser>d__7(int <>1__state) { }

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
	private static Action<Direction> OnClick; //Field offset: 0x0
	[SerializeField]
	private Direction _direction; //Field offset: 0xA0
	private bool _isActive; //Field offset: 0xA4

	public static event Action<Direction> OnClick
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelSlushyDispenser() { }

	[CompilerGenerated]
	public static void add_OnClick(Action<Direction> value) { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnClick(Action<Direction> value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ToggleDispenser() { }

	[IteratorStateMachine(typeof(<TurnOffDispenser>d__7))]
	private IEnumerator TurnOffDispenser(float seconds) { }

}

