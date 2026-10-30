namespace Game.World;

public class LevelWeatherInteractionHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <OnWeatherChangeCoroutine>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WeatherType weatherType; //Field offset: 0x20
		public LevelWeatherInteractionHandler <>4__this; //Field offset: 0x28

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
		public <OnWeatherChangeCoroutine>d__13(int <>1__state) { }

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
	private UnityEvent _onClearStartEvent; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onClearEndEvent; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onRainStartEvent; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onRainEndEvent; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onSnowStartEvent; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onSnowEndEvent; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onHalloweenStartEvent; //Field offset: 0x50
	[SerializeField]
	private UnityEvent _onHalloweenEndEvent; //Field offset: 0x58

	public LevelWeatherInteractionHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnWeatherChange(WeatherType weatherType) { }

	[IteratorStateMachine(typeof(<OnWeatherChangeCoroutine>d__13))]
	private IEnumerator OnWeatherChangeCoroutine(WeatherType weatherType) { }

	private void OnWeatherPostInit() { }

}

