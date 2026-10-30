namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRWaitForResponseData : AFCUnityMessageDrivenHandlerBase
{
	[CompilerGenerated]
	private sealed class <WaitForResponseData>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AFCCRWaitForResponseData <>4__this; //Field offset: 0x20

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
		public <WaitForResponseData>d__5(int <>1__state) { }

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
	private string _cloudResponseKey; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onResponseDataAvailable; //Field offset: 0x30
	private Coroutine _coroutine; //Field offset: 0x38

	public AFCCRWaitForResponseData() { }

	public virtual void PerformAction() { }

	public void StartWaiting() { }

	[IteratorStateMachine(typeof(<WaitForResponseData>d__5))]
	private IEnumerator WaitForResponseData() { }

}

