namespace PazuCore;

public class BottomCat : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlayCatIdleAnimation>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BottomCat <>4__this; //Field offset: 0x20

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
		public <PlayCatIdleAnimation>d__8(int <>1__state) { }

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

	internal enum Type
	{
		Loving = 0,
		Thinking = 1,
		Hurray = 2,
	}

	[SerializeField]
	private Type _type; //Field offset: 0x20
	[SerializeField]
	private SkeletonGraphic _skeletonGraphic; //Field offset: 0x28
	[SerializeField]
	private bool _fitToScreen; //Field offset: 0x30

	public BottomCat() { }

	[CompilerGenerated]
	private void <Show>b__6_0(TrackEntry _) { }

	private void FitToScreen() { }

	private string GetAnimationName(string nameBase) { }

	public void Hide() { }

	[IteratorStateMachine(typeof(<PlayCatIdleAnimation>d__8))]
	private IEnumerator PlayCatIdleAnimation() { }

	public void Show() { }

	private void Start() { }

}

