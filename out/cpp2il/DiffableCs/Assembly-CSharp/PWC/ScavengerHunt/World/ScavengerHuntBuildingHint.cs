namespace PWC.ScavengerHunt.World;

public class ScavengerHuntBuildingHint : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ScavengerHuntBuildingHint <>4__this; //Field offset: 0x20

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
		public <Start>d__6(int <>1__state) { }

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
	private ScavengerHuntType _scavengerHuntType; //Field offset: 0x20
	[SerializeField]
	private GameObject _hint; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _oneItem; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer[] _twoItems; //Field offset: 0x38
	private string _sceneName; //Field offset: 0x40

	public ScavengerHuntBuildingHint() { }

	private void AssignItemSprite(SpriteRenderer spriteRenderer, string prefabGuid) { }

	private void Awake() { }

	private void ShowHintIfNeeded() { }

	[IteratorStateMachine(typeof(<Start>d__6))]
	private IEnumerator Start() { }

}

