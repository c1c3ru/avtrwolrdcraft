namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelFryApplianceHandler : LevelItemDropAreaHandler
{
	[CompilerGenerated]
	private sealed class <Fry>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelFryApplianceHandler <>4__this; //Field offset: 0x20
		public LevelCookableItemHandler fryable; //Field offset: 0x28

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
		public <Fry>d__11(int <>1__state) { }

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
	private ParticleSystem _particleSystem; //Field offset: 0x38
	private LevelFryArea _currentFryArea; //Field offset: 0x40
	private LevelFryDropAreaHandler _currentFryDropAreaHnadler; //Field offset: 0x48
	private Coroutine _fryCoroutine; //Field offset: 0x50

	public LevelFryApplianceHandler() { }

	[IteratorStateMachine(typeof(<Fry>d__11))]
	private IEnumerator Fry(LevelCookableItemHandler fryable) { }

	protected virtual void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnEndLand(LevelDropArea dropArea) { }

	protected virtual void OnItemDropInsideMyDropAreaInternal(LevelItem levelItem) { }

	protected virtual void OnItemPickUpFropMyDropAreaInternal(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	private void ParticleSystemSetActive(bool value) { }

	public void StopFry() { }

	public void TryFry() { }

}

