namespace SimpleEasing;

public class UniqueCoroutine
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Action onFinish; //Field offset: 0x10
		public UniqueCoroutine <>4__this; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <ReplaceOrStartTween>b__0() { }

	}

	private Coroutine coroutine; //Field offset: 0x10
	private MonoBehaviour callingScript; //Field offset: 0x18
	private Tween currentTween; //Field offset: 0x20

	public bool IsRunning
	{
		 get { } //Length: 16
	}

	public UniqueCoroutine(IEnumerator enumerator, MonoBehaviour script) { }

	public UniqueCoroutine() { }

	public bool get_IsRunning() { }

	public void ReplaceOrStartCoroutine(IEnumerator enumerator, MonoBehaviour script) { }

	public void ReplaceOrStartCoroutine(Coroutine routine, MonoBehaviour script) { }

	public void ReplaceOrStartCoroutine(Coroutine routine) { }

	public void ReplaceOrStartTween(Coroutine routine) { }

	public void ReplaceOrStartTween(Tween t) { }

	public void StopCoroutine() { }

}

