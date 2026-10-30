namespace Game.World;

public class LevelSpriteRendererVisibleByWeatherManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DelayedStartFade>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelSpriteRendererVisibleByWeatherManager <>4__this; //Field offset: 0x20

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
		public <DelayedStartFade>d__9(int <>1__state) { }

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

	private class FadeEntry
	{
		public SpriteRenderer renderer; //Field offset: 0x10
		public float startAlpha; //Field offset: 0x18
		public float targetAlpha; //Field offset: 0x1C

		public FadeEntry() { }

	}

	public static LevelSpriteRendererVisibleByWeatherManager Instance; //Field offset: 0x0
	private List<FadeEntry> _fadingSprites; //Field offset: 0x20
	private bool _fadeScheduled; //Field offset: 0x28
	private float _fadeDuration; //Field offset: 0x2C
	private int _currentTweenId; //Field offset: 0x30

	public LevelSpriteRendererVisibleByWeatherManager() { }

	[CompilerGenerated]
	private void <StartFade>b__10_0(float t) { }

	[CompilerGenerated]
	private void <StartFade>b__10_1() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<DelayedStartFade>d__9))]
	private IEnumerator DelayedStartFade() { }

	private void OnDestroy() { }

	public void RequestFade(SpriteRenderer sr, float targetAlpha, float duration) { }

	private void StartFade(float duration) { }

}

