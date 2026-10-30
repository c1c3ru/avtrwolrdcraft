namespace Game.Level;

public class LevelCameraFollowSking : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <FollowCamera>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCameraFollowSking <>4__this; //Field offset: 0x20

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
		public <FollowCamera>d__11(int <>1__state) { }

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
	private LevelDropArea _skiDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelCamera _camera; //Field offset: 0x28
	[SerializeField]
	private GameCameraScrollArea _cameraScrollArea; //Field offset: 0x30
	[SerializeField]
	private float _offsetX; //Field offset: 0x38
	private bool _isFollowing; //Field offset: 0x3C
	private LevelItem _levelItem; //Field offset: 0x40
	private Coroutine followCoroutine; //Field offset: 0x48

	public LevelCameraFollowSking() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<FollowCamera>d__11))]
	private IEnumerator FollowCamera() { }

	private bool IsPointerOverUI() { }

	private void OnDestroy() { }

	private void StartFollow() { }

	private void StopFollow() { }

}

