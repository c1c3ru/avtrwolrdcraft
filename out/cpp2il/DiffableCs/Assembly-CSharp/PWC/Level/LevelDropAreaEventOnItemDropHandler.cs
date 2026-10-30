namespace PWC.Level;

public class LevelDropAreaEventOnItemDropHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <WaitForDropAreaEmpty>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelDropAreaEventOnItemDropHandler <>4__this; //Field offset: 0x20

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
		public <WaitForDropAreaEmpty>d__27(int <>1__state) { }

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
	public UnityEvent OnItemDropAction; //Field offset: 0x20
	[SerializeField]
	public UnityEvent OnItemPickUpAction; //Field offset: 0x28
	[SerializeField]
	public UnityEvent OnFirstItemDropAction; //Field offset: 0x30
	[SerializeField]
	public UnityEvent OnDropAreaEmptyAction; //Field offset: 0x38
	[SerializeField]
	public UnityEvent OnItemBeginDropAction; //Field offset: 0x40
	[SerializeField]
	protected bool _invokeDropEventOnPostInit; //Field offset: 0x48
	[SerializeField]
	protected bool _invokePickUpEventOnPostInit; //Field offset: 0x49
	[SerializeField]
	protected bool _invokeFirstItemDropSeperatly; //Field offset: 0x4A
	[SerializeField]
	protected bool _invokeEmptyDropAreaSeperatly; //Field offset: 0x4B
	[SerializeField]
	protected bool _IsLabelNeeded; //Field offset: 0x4C
	[ConditionalField("_IsLabelNeeded", True, True, (array) null)]
	[SerializeField]
	private string _label; //Field offset: 0x50
	[SerializeField]
	protected int _specificAvatarID; //Field offset: 0x58
	protected LevelDropArea _dropArea; //Field offset: 0x60
	protected LevelConsumerAreaBase _consumerArea; //Field offset: 0x68
	private LevelHangArea _hangArea; //Field offset: 0x70
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x78

	public LevelDropAreaEventOnItemDropHandler() { }

	[CompilerGenerated]
	private bool <WaitForDropAreaEmpty>b__27_0() { }

	protected override void Awake() { }

	protected override bool CheckIfAvatarIDIsInDropArea(LevelItem givenItem = null) { }

	private void EnsureOnReadyPostLoad() { }

	protected override bool IsConditionMet(LevelItem levelItem) { }

	protected override void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	protected override void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar __) { }

	private void OnDestroy() { }

	protected override void OnItemBeginDrop(LevelItem levelItem) { }

	protected override void OnItemEndDrop(LevelItem levelItem) { }

	protected override void OnItemPickUp(LevelItem levelItem) { }

	public void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	[IteratorStateMachine(typeof(<WaitForDropAreaEmpty>d__27))]
	protected IEnumerator WaitForDropAreaEmpty() { }

}

