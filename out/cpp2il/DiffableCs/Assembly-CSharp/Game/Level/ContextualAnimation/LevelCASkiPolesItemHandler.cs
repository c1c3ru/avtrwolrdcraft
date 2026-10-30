namespace Game.Level.ContextualAnimation;

public class LevelCASkiPolesItemHandler : LevelCAItemHandlerWithSwappableData
{
	[CompilerGenerated]
	private sealed class <FallCoroutine>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCASkiPolesItemHandler <>4__this; //Field offset: 0x20

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
		public <FallCoroutine>d__28(int <>1__state) { }

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

	private const string FALL_OFF_ANIMATION_NAME = "Fall_Get_Up"; //Field offset: 0x0
	private const string DISMOUNT_ANIMATION_NAME = "Stop"; //Field offset: 0x0
	private static readonly List<String> SUTS_TO_CHECK; //Field offset: 0x0
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0xA0
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0xA8
	[SerializeField]
	private string _skinName; //Field offset: 0xB0
	[SerializeField]
	private LevelCAItemHandlerData _skiPoleData; //Field offset: 0xB8
	private LevelCharacter _levelCharacter; //Field offset: 0xC0
	private LevelCharacterMovementOverrideHandler _movementOverrideHandler; //Field offset: 0xC8
	private LevelCARollerBladeItemHelper _helper; //Field offset: 0xD0
	private bool _isFalling; //Field offset: 0xD8

	private static LevelCASkiPolesItemHandler() { }

	public LevelCASkiPolesItemHandler() { }

	private void AddCA() { }

	protected virtual void Awake() { }

	public virtual bool CanTargetHoldItems() { }

	public virtual bool CanTargetHoldSpecificItem(LevelItem levelItem) { }

	protected virtual void EnsureOnReadyPostLoad() { }

	[IteratorStateMachine(typeof(<FallCoroutine>d__28))]
	private IEnumerator FallCoroutine() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void OnApplicationPause(bool pause) { }

	protected virtual void OnDestroy() { }

	private void OnPutClothing(string skinName) { }

	private void OnRemoveClothing(string skinName) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private bool OverrideCharacterPlayProperIdleAnimation() { }

	private void RemoveCA() { }

	private bool TryFindSut() { }

	private bool TryFindSutFromSkin(string skin) { }

	public static bool TryFindSutStatic(LevelCharacter character) { }

}

