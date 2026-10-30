namespace Game.Level;

public class LevelAppliancesMachineHelper : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <PlaySound>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelAppliancesMachineHelper <>4__this; //Field offset: 0x20

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
		public <PlaySound>d__14(int <>1__state) { }

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
	private LevelDropArea[] _dropAreas; //Field offset: 0x20
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x38
	[SerializeField]
	private string _workSoundName; //Field offset: 0x40
	[SerializeField]
	private string _turnOnSoundName; //Field offset: 0x48
	[SerializeField]
	private string _turnOffSoundName; //Field offset: 0x50
	[SerializeField]
	public UnityEvent onStartMachineWithItemsAction; //Field offset: 0x58
	[SerializeField]
	public UnityEvent onStopMachineWithItemsAction; //Field offset: 0x60

	public LevelAppliancesMachineHelper() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private bool IsEmpty() { }

	private void OnDestroy() { }

	public void OnDoorStateChange(bool isOpen) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	[IteratorStateMachine(typeof(<PlaySound>d__14))]
	private IEnumerator PlaySound() { }

	private void StartSound() { }

	private void StopSound() { }

}

