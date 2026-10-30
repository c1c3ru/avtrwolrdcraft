namespace PWC;

public class BackgroundPlanetSoundHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public string abientSoundName; //Field offset: 0x10
		public BackgroundPlanetSoundHandler <>4__this; //Field offset: 0x18
		public AudioSource audioSource; //Field offset: 0x20
		public Action<Single> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass13_0() { }

		internal void <PlayAmbient>b__0(float value) { }

		internal void <PlayAmbient>b__1() { }

		internal void <PlayAmbient>b__2(float value) { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BackgroundPlanetSoundHandler <>4__this; //Field offset: 0x20

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
		public <Start>d__9(int <>1__state) { }

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
	private BackgroundPlanet _planet; //Field offset: 0x20
	[SerializeField]
	private string _clickDaySound; //Field offset: 0x28
	[SerializeField]
	private string _clickSunsetSound; //Field offset: 0x30
	[SerializeField]
	private string _clickNightSound; //Field offset: 0x38
	[SerializeField]
	private string _dayAmbientSound; //Field offset: 0x40
	[SerializeField]
	private string _sunsetAmbientSound; //Field offset: 0x48
	[SerializeField]
	private string _nightAmbientSound; //Field offset: 0x50
	private int _tweenId; //Field offset: 0x58

	public BackgroundPlanetSoundHandler() { }

	private void Awake() { }

	private void OnBeforeSceneLoadStage1() { }

	private void OnDestroy() { }

	private void OnPlanetClick(TimeOfDay timeOfDay) { }

	private void PlayAmbient(TimeOfDay timeOfDay, bool useSmoothTransition) { }

	public void SetSounds(string daySound, string sunsetSound, string nightSound) { }

	[IteratorStateMachine(typeof(<Start>d__9))]
	private IEnumerator Start() { }

}

