namespace PWC.AvatarMaker;

public abstract class AvatarMakerAvatarManagerBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AnimationTimer>d__29 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarMakerAvatarManagerBase <>4__this; //Field offset: 0x20

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
		public <AnimationTimer>d__29(int <>1__state) { }

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

	private const string IDLE_ANIMATION_NAME = "Idle_Stand_1"; //Field offset: 0x0
	public static Action<TemplateRestoreData> OnAvatarSlotChangedStaticAction; //Field offset: 0x0
	public static Action<AvatarSpineData> OnAvatarRebuiltStaticAction; //Field offset: 0x8
	public static Action<Int32, Color[]> OnAvatarColoredTemplateChangedStaticAction; //Field offset: 0x10
	public static Action<Color, Color[]> OnAvatarColoredSkinChangedStaticAction; //Field offset: 0x18
	[SerializeField]
	protected AvatarSpineSkinsManagerBase _skinsManager; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	protected SUTSkinsDataMap _sutSkinsDataMap; //Field offset: 0x30
	protected Dictionary<Int32, List`1<String>> _skinNamesForRandom; //Field offset: 0x38
	protected int _sizeTweenID; //Field offset: 0x40
	private bool _canAnimate; //Field offset: 0x44
	protected SkeletonDataAsset _skeletonData; //Field offset: 0x48
	[CompilerGenerated]
	private bool <DidPressAnythingBeforeRandomButton>k__BackingField; //Field offset: 0x50
	private int _lastHistoryRecordFrame; //Field offset: 0x54

	public private bool DidPressAnythingBeforeRandomButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public SkeletonAnimation SkeletonAnimation
	{
		 get { } //Length: 8
	}

	public AvatarSpineSkinsManagerBase SkinsManager
	{
		 get { } //Length: 8
	}

	protected AvatarMakerAvatarManagerBase() { }

	[CompilerGenerated]
	private void <SetLookAtAnimation>b__26_0(TrackEntry x) { }

	[IteratorStateMachine(typeof(<AnimationTimer>d__29))]
	private IEnumerator AnimationTimer() { }

	protected override void Awake() { }

	[CompilerGenerated]
	public bool get_DidPressAnythingBeforeRandomButton() { }

	public SkeletonAnimation get_SkeletonAnimation() { }

	public AvatarSpineSkinsManagerBase get_SkinsManager() { }

	protected HashSet<String> GetAllExpansionPackItems(SpineType spineType) { }

	protected override string GetIdleAnimationName() { }

	protected override string GetLookAtAnimationName(int categoryType) { }

	public void Init(int id) { }

	private void OnColorThumbClick(ColorButtonConfig buttonConfig) { }

	private void OnDelete(AvatarMakerThumb thumb) { }

	protected override void OnDestroy() { }

	protected override void OnThumbClick(AvatarMakerThumb thumb) { }

	public void PlayPuffEffect() { }

	public override void RandomizeSkins() { }

	public void RecordAvatarRebuildForHistory() { }

	protected void RecordSkinChangeForHistory(int categoryType, string skinNameToAdd = null) { }

	protected void RecordSkinColorChangeForHistory() { }

	protected void RecordTemplateColorChangeForHistory(int categoryType) { }

	protected void ScaleToSizeType(AvatarSizeType sizeType) { }

	[CompilerGenerated]
	private void set_DidPressAnythingBeforeRandomButton(bool value) { }

	private void SetLookAtAnimation(int categoryType) { }

	private bool TryMultiColorAssignment(ColorButtonConfig buttonConfig) { }

	private bool TryStartHistoryRecord() { }

}

