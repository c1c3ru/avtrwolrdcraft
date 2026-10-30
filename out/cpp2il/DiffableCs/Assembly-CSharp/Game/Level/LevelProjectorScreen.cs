namespace Game.Level;

public class LevelProjectorScreen : LevelFoldableItem
{
	[CompilerGenerated]
	private sealed class <OnLandCoroutine>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelProjectorScreen <>4__this; //Field offset: 0x20

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
		public <OnLandCoroutine>d__13(int <>1__state) { }

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

	private readonly Dictionary<LevelProjector, SpriteRenderer> _pictureByProjector; //Field offset: 0x390
	private SpriteRenderer _spriteRenderer; //Field offset: 0x398
	private Coroutine _onLandCoroutine; //Field offset: 0x3A0

	public LevelProjectorScreen() { }

	protected virtual void Awake() { }

	private void DestoryPicture(LevelProjector projector, GameObject picture) { }

	private void OnBeforeProjectorDestroyWhileInGameplay(LevelItem levelItem) { }

	protected virtual void OnBeginLand(LevelDropArea dropArea) { }

	protected virtual void OnDestroy() { }

	protected virtual LevelDropArea OnEndLand() { }

	[IteratorStateMachine(typeof(<OnLandCoroutine>d__13))]
	private IEnumerator OnLandCoroutine() { }

	protected virtual void OnParentBeginLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected virtual void OnParentEndLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected virtual void OnParentSyncPosition(LevelItem parentLevelItem, Vector2 pointerPosition) { }

	private void OnPictureSyncPosition(LevelProjector projector) { }

	private void OnProjectorToggleState(LevelProjector projector) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	private void SyncAllPicturesPositions() { }

	private void SyncPicture(LevelProjector projector, SpriteRenderer picture) { }

}

