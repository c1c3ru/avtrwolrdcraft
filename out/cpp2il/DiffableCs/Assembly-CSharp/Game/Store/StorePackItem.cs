namespace Game.Store;

public class StorePackItem : StorePackItemBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public StorePackItem <>4__this; //Field offset: 0x10
		public Action onResetAction; //Field offset: 0x18

		public <>c__DisplayClass29_0() { }

		internal void <OpenResetPackWindow>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <SyncAvailableInDurationTimer>d__31 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StorePackItem <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28
		private float <timeBefore>5__3; //Field offset: 0x30

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
		public <SyncAvailableInDurationTimer>d__31(int <>1__state) { }

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
	private StorePackItemPriceViewer _priceViewer; //Field offset: 0x38
	[SerializeField]
	private StorePackItemOfferViewer _offerViewer; //Field offset: 0x40
	[SerializeField]
	private StorePackItemStarsViewer _starsViewer; //Field offset: 0x48
	[SerializeField]
	private GameObject _comingSoon; //Field offset: 0x50
	[SerializeField]
	private TextMeshProUGUI _comingSoonText; //Field offset: 0x58
	[SerializeField]
	private GameObject _avatarPassBadge; //Field offset: 0x60
	[SerializeField]
	private GameObject _ownedBadge; //Field offset: 0x68
	[SerializeField]
	private GameObject _resetPackButton; //Field offset: 0x70
	[SerializeField]
	private Image _bundleImage; //Field offset: 0x78
	[SerializeField]
	private GameObject _comgingSoonBubble; //Field offset: 0x80
	[SerializeField]
	private GameObject _giftBadge; //Field offset: 0x88
	[SerializeField]
	private GameObject _coverForReveal; //Field offset: 0x90
	[SerializeField]
	private GameObject _packOfBundleClaimButton; //Field offset: 0x98
	[SerializeField]
	private GameObject[] _inactiveWhenCoverForReveal; //Field offset: 0xA0
	private bool _hasItemsInLevels; //Field offset: 0xA8
	private TimeSpan _availableInDuration; //Field offset: 0xB0
	private StoreTweenToolipHandle _tweenTooltipHandle; //Field offset: 0xB8
	[CompilerGenerated]
	private Action<StorePackItem> OnItemSyncViewAction; //Field offset: 0xC0

	public event Action<StorePackItem> OnItemSyncViewAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public StorePackItem() { }

	[CompilerGenerated]
	private void <SyncAvailableInDurationTimer>g__SyncText|31_0() { }

	[CompilerGenerated]
	private void <SyncStateToItem>g__SetOwnedBadgeActive|28_1(bool isActive) { }

	[CompilerGenerated]
	private void <SyncStateToItem>g__SetResetPackButtonActive|28_0(bool isActive) { }

	[CompilerGenerated]
	public void add_OnItemSyncViewAction(Action<StorePackItem> value) { }

	private string GetCoverToRevealClickedKey() { }

	public bool HasItemsInLevels() { }

	public virtual void Init(Item itemData) { }

	public void InitAvatarPassMode() { }

	private bool IsClaimableAndPartOfClaimedBundleInBundleView() { }

	protected virtual void OnClickWhileClaimable() { }

	protected virtual void OnClickWhileClaimed() { }

	protected virtual void OnClickWhileComingSoon() { }

	protected virtual void OnClickWhileLinkToPack() { }

	protected virtual void OnClickWhileSuggestAvatarPass() { }

	protected override void OnInit() { }

	public void OnResetPackButtonClick() { }

	public void OpenResetPackWindow(Action onResetAction = null) { }

	[CompilerGenerated]
	public void remove_OnItemSyncViewAction(Action<StorePackItem> value) { }

	private void ShowCoverForReveal(bool show) { }

	private void ShowPackItemWindow() { }

	[IteratorStateMachine(typeof(<SyncAvailableInDurationTimer>d__31))]
	private IEnumerator SyncAvailableInDurationTimer() { }

	public override void SynceView() { }

	private void SyncStateToItem(Item itemData, bool isRecursiveCall) { }

	protected override bool TryClickOnCoverForReveal() { }

}

