namespace Game.Level;

public class LevelShopPack : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <DestroyPack>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelShopPack <>4__this; //Field offset: 0x20

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
		public <DestroyPack>d__26(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <DisableCShape>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelShopPack <>4__this; //Field offset: 0x20

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
		public <DisableCShape>d__25(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ParticlesCoroutine>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelShopPack <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28
		private ParticlesTimingData <data>5__3; //Field offset: 0x30

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
		public <ParticlesCoroutine>d__24(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <PlayAlternateIdleAnimations>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelShopPack <>4__this; //Field offset: 0x20

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
		public <PlayAlternateIdleAnimations>d__20(int <>1__state) { }

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

	[Header("Spine")]
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	[SpineAnimation(null, "skeletonDataAsset", True, False, False)]
	private string _onClickAnimation; //Field offset: 0x28
	[SerializeField]
	[SpineAnimation(null, "skeletonDataAsset", True, False, False)]
	private string _idleAnimation; //Field offset: 0x30
	[SerializeField]
	private float _alternateIdleAnimationsInterval; //Field offset: 0x38
	[SerializeField]
	[SpineAnimation(null, "skeletonDataAsset", True, False, False)]
	private List<String> _alteranteIdleAnimations; //Field offset: 0x40
	[Header("Particles")]
	[SerializeField]
	private ParticlesTimingData[] _particlesTimings; //Field offset: 0x48
	[SerializeField]
	private CShape _cShape; //Field offset: 0x50
	[SerializeField]
	private float _timeTillDestroy; //Field offset: 0x58
	[SerializeField]
	private float _timeTillCshapeDisable; //Field offset: 0x5C
	[SerializeField]
	private GameObject[] _boxes; //Field offset: 0x60
	[SerializeField]
	private bool _newSpineBox; //Field offset: 0x68
	private bool _didOnReadyPostLoad; //Field offset: 0x69
	private bool _isClicked; //Field offset: 0x6A

	public LevelShopPack() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<DestroyPack>d__26))]
	private IEnumerator DestroyPack() { }

	[IteratorStateMachine(typeof(<DisableCShape>d__25))]
	private IEnumerator DisableCShape() { }

	private void EnsureOnReadyPostLoad() { }

	private void MoveNewBoxesOut() { }

	public void OnAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnPreSaveProgress(Scene scene) { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	[IteratorStateMachine(typeof(<ParticlesCoroutine>d__24))]
	private IEnumerator ParticlesCoroutine() { }

	[IteratorStateMachine(typeof(<PlayAlternateIdleAnimations>d__20))]
	private IEnumerator PlayAlternateIdleAnimations() { }

	private void PlayAnimation(string animationName, bool isLoop) { }

}

