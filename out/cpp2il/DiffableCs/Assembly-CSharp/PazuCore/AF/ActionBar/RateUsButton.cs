namespace PazuCore.AF.ActionBar;

public class RateUsButton : Selectable, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <PlayAnimation>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RateUsButton <>4__this; //Field offset: 0x20

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
		public <PlayAnimation>d__8(int <>1__state) { }

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
	private RectTransform _shine; //Field offset: 0x100
	[SerializeField]
	private Graphic _heart; //Field offset: 0x108

	public RateUsButton() { }

	[CompilerGenerated]
	private void <PlayAnimation>b__8_0() { }

	protected virtual void Awake() { }

	private bool CanShowRateUs() { }

	private void HideRateUsButton() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEnable() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[IteratorStateMachine(typeof(<PlayAnimation>d__8))]
	private IEnumerator PlayAnimation() { }

}

