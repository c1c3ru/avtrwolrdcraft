namespace Game.Level;

public class LevelItemsMenuShopPack : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, ILevelSpawnDuringGameplay, IPDItemsMenuPack, IPDPack, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public LevelItemsMenuShopPack <>4__this; //Field offset: 0x10
		public string soundName; //Field offset: 0x18

		public <>c__DisplayClass35_0() { }

		internal void <OnAnimationEvent>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <DestroyPack>d__37 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelItemsMenuShopPack <>4__this; //Field offset: 0x20

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
		public <DestroyPack>d__37(int <>1__state) { }

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
	private sealed class <ParticlesCoroutine>d__36 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelItemsMenuShopPack <>4__this; //Field offset: 0x20
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
		public <ParticlesCoroutine>d__36(int <>1__state) { }

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
	private sealed class <PlayAlternateIdleAnimations>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelItemsMenuShopPack <>4__this; //Field offset: 0x20

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
		public <PlayAlternateIdleAnimations>d__28(int <>1__state) { }

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
	private GameSoundPlayer _soundPlayer; //Field offset: 0x60
	[SerializeField]
	private bool _openOnPostLoad; //Field offset: 0x68
	[SerializeField]
	private string _nameOfPackInItemsMenu; //Field offset: 0x70
	private bool _didOnReadyPostLoad; //Field offset: 0x78
	private bool _isClicked; //Field offset: 0x79
	private SortingGroup _sortingGroup; //Field offset: 0x80
	[CompilerGenerated]
	private bool <ShouldDropRootItemsInSpawnPosition>k__BackingField; //Field offset: 0x88

	public bool ShouldDropRootItemsInSpawnPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelItemsMenuShopPack() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<DestroyPack>d__37))]
	private IEnumerator DestroyPack() { }

	private void EnsureOnReadyPostLoad() { }

	[CompilerGenerated]
	public bool get_ShouldDropRootItemsInSpawnPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPointerClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnPreSaveCurrentSceneAndSendStartSceneEvent() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	[IteratorStateMachine(typeof(<ParticlesCoroutine>d__36))]
	private IEnumerator ParticlesCoroutine() { }

	[IteratorStateMachine(typeof(<PlayAlternateIdleAnimations>d__28))]
	private IEnumerator PlayAlternateIdleAnimations() { }

	private void PlayAnimation(string animationName, bool isLoop) { }

	private override StorePackType PWC.PersistentData.IPDItemsMenuPack.GetStorePackType() { }

	[CompilerGenerated]
	public void set_ShouldDropRootItemsInSpawnPosition(bool value) { }

	public void SetNameOfPackInItemsMenu(string nameOfPackInItemsMenu) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private bool TryAnimateItemsToLevelMakerMenu() { }

}

