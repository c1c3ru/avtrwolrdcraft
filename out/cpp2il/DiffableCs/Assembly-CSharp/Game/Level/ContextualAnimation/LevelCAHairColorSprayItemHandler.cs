namespace Game.Level.ContextualAnimation;

public class LevelCAHairColorSprayItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <TryColorOtherCharacters>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCharacter holderCharacter; //Field offset: 0x20
		public LevelCAHairColorSprayItemHandler <>4__this; //Field offset: 0x28

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
		public <TryColorOtherCharacters>d__8(int <>1__state) { }

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

	private LevelHairColorSpray _hairColorSpray; //Field offset: 0x88
	private Coroutine _coroutine; //Field offset: 0x90
	private readonly HashSet<LevelCharacter> _affectingCharacters; //Field offset: 0x98

	public LevelCAHairColorSprayItemHandler() { }

	[CompilerGenerated]
	internal static List<LevelCAConfig> <GetAnimations>g__Get|4_0(ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void Awake() { }

	private bool CanAffectCharactger(LevelCharacter character) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void StopTryColorOtherCharacters() { }

	[IteratorStateMachine(typeof(<TryColorOtherCharacters>d__8))]
	private IEnumerator TryColorOtherCharacters(LevelCharacter holderCharacter) { }

}

