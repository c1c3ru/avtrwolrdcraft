namespace Game.World;

[DefaultExecutionOrder(1)]
public class HolidayGameModeButton : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public string packGuid; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal bool <OnButtonPress>b__0(Item i) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public HolidayGameModeButton <>4__this; //Field offset: 0x10
		public bool isEnableHolidayPopup; //Field offset: 0x18

		public <>c__DisplayClass19_0() { }

		internal void <OnClick>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <Start>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public HolidayGameModeButton <>4__this; //Field offset: 0x20

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
		public <Start>d__14(int <>1__state) { }

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

	private static readonly LevelWorldType[] _holidayWeatherWorlds; //Field offset: 0x0
	[SerializeField]
	private Image _backgroundImage; //Field offset: 0x20
	[SerializeField]
	private Sprite _activeBackgroundHoliday; //Field offset: 0x28
	[SerializeField]
	private Sprite _disableBackgroundHoliday; //Field offset: 0x30
	[SerializeField]
	private Image _buttonImage; //Field offset: 0x38
	[SerializeField]
	private Sprite _activeButtonHoliday; //Field offset: 0x40
	[SerializeField]
	private Sprite _disabledButtonHoliday; //Field offset: 0x48
	[SerializeField]
	private HuntData[] _eventHunts; //Field offset: 0x50
	[SerializeField]
	private string _regularThemeSoundName; //Field offset: 0x58
	[SerializeField]
	private string _holidaySoundName; //Field offset: 0x60

	private static HolidayGameModeButton() { }

	public HolidayGameModeButton() { }

	protected virtual void Awake() { }

	private void EnableEventHunts() { }

	public string GetWeatherTypePrefKey(string world) { }

	public void OnButtonPress() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void OnEnterMultiplayer() { }

	private void OnExitMultiplayer() { }

	private void PlayBackgroundMusic(bool isHolidayEnabled) { }

	private void SetHolidayWeatherOnWorlds() { }

	[IteratorStateMachine(typeof(<Start>d__14))]
	private IEnumerator Start() { }

}

