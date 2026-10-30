namespace TMPro;

[DisallowMultipleComponent]
public class TMP_SpriteAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DoSpriteAnimationInternal>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TMP_SpriteAnimator <>4__this; //Field offset: 0x20
		public int start; //Field offset: 0x28
		public int end; //Field offset: 0x2C
		public TMP_SpriteAsset spriteAsset; //Field offset: 0x30
		public int currentCharacter; //Field offset: 0x38
		public int framerate; //Field offset: 0x3C
		private int <currentFrame>5__2; //Field offset: 0x40
		private TMP_CharacterInfo <charInfo>5__3; //Field offset: 0x48
		private int <materialIndex>5__4; //Field offset: 0x1C0
		private int <vertexIndex>5__5; //Field offset: 0x1C4
		private TMP_MeshInfo <meshInfo>5__6; //Field offset: 0x1C8
		private float <baseSpriteScale>5__7; //Field offset: 0x218
		private float <elapsedTime>5__8; //Field offset: 0x21C
		private float <targetTime>5__9; //Field offset: 0x220

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
		public <DoSpriteAnimationInternal>d__7(int <>1__state) { }

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

	private Dictionary<Int32, Boolean> m_animations; //Field offset: 0x20
	private TMP_Text m_TextComponent; //Field offset: 0x28

	public TMP_SpriteAnimator() { }

	private void Awake() { }

	public void DoSpriteAnimation(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate) { }

	[IteratorStateMachine(typeof(<DoSpriteAnimationInternal>d__7))]
	private IEnumerator DoSpriteAnimationInternal(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate) { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void StopAllAnimations() { }

}

