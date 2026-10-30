namespace Game.Level;

public class LevelPDBulkDataShopPack : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, ILevelSpawnDuringGameplay, IHasPDTextBulkData, IPDPack, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public LevelPDBulkDataShopPack <>4__this; //Field offset: 0x10
		public string soundName; //Field offset: 0x18

		public <>c__DisplayClass41_0() { }

		internal void <OnAnimationEvent>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <DestroyPack>d__43 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPDBulkDataShopPack <>4__this; //Field offset: 0x20

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
		public <DestroyPack>d__43(int <>1__state) { }

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
	private sealed class <ParticlesCoroutine>d__42 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPDBulkDataShopPack <>4__this; //Field offset: 0x20
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
		public <ParticlesCoroutine>d__42(int <>1__state) { }

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
	private sealed class <PlayAlternateIdleAnimations>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPDBulkDataShopPack <>4__this; //Field offset: 0x20

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
		public <PlayAlternateIdleAnimations>d__34(int <>1__state) { }

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
	private sealed class <SpawnScatter>d__39 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPDBulkDataShopPack <>4__this; //Field offset: 0x20

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
		public <SpawnScatter>d__39(int <>1__state) { }

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

	public static Action<StorePackType> OnPackSpawn; //Field offset: 0x0
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
	private float _timeTillSpawn; //Field offset: 0x5C
	[SerializeField]
	private PDTextBulkData _scatterBulkData; //Field offset: 0x60
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68
	[SerializeField]
	private bool _openOnPostLoad; //Field offset: 0x70
	[SerializeField]
	private string _nameOfPackInItemsMenu; //Field offset: 0x78
	private bool _didOnReadyPostLoad; //Field offset: 0x80
	private bool _isClicked; //Field offset: 0x81
	private SortingGroup _sortingGroup; //Field offset: 0x88
	private bool _didSpawnScatter; //Field offset: 0x90
	private bool _shouldSpawnItems; //Field offset: 0x91
	[CompilerGenerated]
	private bool <ShouldDropRootItemsInSpawnPosition>k__BackingField; //Field offset: 0x92
	public Action<LevelPDBulkDataShopPack, List`1<Transform>> OnSpawnScatterAction; //Field offset: 0x98

	public string nameOfPackInItemsMenu
	{
		 get { } //Length: 8
	}

	public bool ShouldDropRootItemsInSpawnPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelPDBulkDataShopPack() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<DestroyPack>d__43))]
	private IEnumerator DestroyPack() { }

	private void DropRootItemsInSpawnPosition(List<Transform> instances) { }

	private void EnsureOnReadyPostLoad() { }

	public string get_nameOfPackInItemsMenu() { }

	[CompilerGenerated]
	public bool get_ShouldDropRootItemsInSpawnPosition() { }

	public override PDTextBulkData GetPDTextBulkData() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnPointerClick() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnPreSaveCurrentSceneAndSendStartSceneEvent() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	[IteratorStateMachine(typeof(<ParticlesCoroutine>d__42))]
	private IEnumerator ParticlesCoroutine() { }

	[IteratorStateMachine(typeof(<PlayAlternateIdleAnimations>d__34))]
	private IEnumerator PlayAlternateIdleAnimations() { }

	private void PlayAnimation(string animationName, bool isLoop) { }

	[CompilerGenerated]
	public void set_ShouldDropRootItemsInSpawnPosition(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	[IteratorStateMachine(typeof(<SpawnScatter>d__39))]
	private IEnumerator SpawnScatter() { }

	private bool TryAnimateItemsToLevelMakerMenu() { }

}

