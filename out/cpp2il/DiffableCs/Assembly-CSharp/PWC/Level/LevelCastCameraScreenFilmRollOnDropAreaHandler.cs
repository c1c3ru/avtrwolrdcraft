namespace PWC.Level;

public class LevelCastCameraScreenFilmRollOnDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CastCoroutine>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCastCameraScreenFilmRollOnDropAreaHandler <>4__this; //Field offset: 0x20
		private SpriteRenderer[] <spriteRenderers>5__2; //Field offset: 0x28
		private int <length>5__3; //Field offset: 0x30

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
		public <CastCoroutine>d__16(int <>1__state) { }

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

	[Header("Scene References")]
	[SerializeField]
	protected MeshRenderer _castPreview; //Field offset: 0x20
	[SerializeField]
	private bool _isPlaybleProjector; //Field offset: 0x28
	private readonly int _MainTexID; //Field offset: 0x2C
	private float _secondsBetweenPhotos; //Field offset: 0x30
	private bool _isCasting; //Field offset: 0x34
	private int _currentIndex; //Field offset: 0x38
	private LevelCameraScreenFilmRoll _currentFilmRoll; //Field offset: 0x40
	private LevelSingleItemDropArea _dropArea; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onPutFullMovieAction; //Field offset: 0x50

	public LevelCastCameraScreenFilmRollOnDropAreaHandler() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<CastCoroutine>d__16))]
	private IEnumerator CastCoroutine() { }

	private void CastCurrentFilmRollToScreen() { }

	private ValueTuple<Texture2D, Material> GetTransparentTexture2D() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInitHandler() { }

	private void SetTextureOnCastPreview(ValueTuple<Texture, Material> textureAndMaterial) { }

	private void StopCastingToScreen() { }

}

