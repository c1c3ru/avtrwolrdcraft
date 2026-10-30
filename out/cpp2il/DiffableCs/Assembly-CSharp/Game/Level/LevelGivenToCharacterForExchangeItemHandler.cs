namespace Game.Level;

public class LevelGivenToCharacterForExchangeItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public LevelGivenToCharacterForExchangeItemHandler <>4__this; //Field offset: 0x10
		public ILevelAvatar avatar; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <OnPlacedOnAvatarWithHands>b__0() { }

		internal bool <OnPlacedOnAvatarWithHands>b__1(PDPrefab x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_1
	{
		public ILevelAnimatable animatable; //Field offset: 0x10
		public <>c__DisplayClass26_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass26_1() { }

		internal void <OnPlacedOnAvatarWithHands>b__2() { }

	}

	internal sealed class CanPlaceOnAvatarHandDelegate : MulticastDelegate
	{

		public CanPlaceOnAvatarHandDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ILevelAvatar levelAvatar, LevelItem levelItem, ref bool canConsume, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool canConsume, IAsyncResult result) { }

		public override void Invoke(ILevelAvatar levelAvatar, LevelItem levelItem, ref bool canConsume) { }

	}

	[SerializeField]
	protected LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x28
	[SerializeField]
	protected int _characterID; //Field offset: 0x30
	[SerializeField]
	protected string _prizeSoundName; //Field offset: 0x38
	[SerializeField]
	protected bool _keepItem; //Field offset: 0x40
	[SerializeField]
	protected List<MethodGivenToCharacter> _allowedMethodsGivenToCharacter; //Field offset: 0x48
	[SerializeField]
	private bool _isSpecificPrefabParent; //Field offset: 0x50
	[ConditionalField("_isSpecificPrefabParent", True, True, (array) null)]
	[SerializeField]
	private PDPrefabReference _pdPrefabParent; //Field offset: 0x58
	[SerializeField]
	private string _giveAnimationName; //Field offset: 0x60
	[SerializeField]
	protected AvatarHandType _forceHand; //Field offset: 0x68
	[SerializeField]
	private UnityEvent _onGiftAcceptedEvents; //Field offset: 0x70
	[CompilerGenerated]
	private CanPlaceOnAvatarHandDelegate CanPlaceOnAvatarHandsAction; //Field offset: 0x78
	private PDPrefab _giftPDPrefab; //Field offset: 0x80
	private ILevelHasHands _givingAvatarWithHands; //Field offset: 0x88
	private bool _isReceivingItem; //Field offset: 0x90
	private bool _waitForCurrentAnimationEnd; //Field offset: 0x91
	private bool _hasInvokedGiftAcceptedEvents; //Field offset: 0x92
	private ItemOnAvatarType _givingAvatarHand; //Field offset: 0x94

	public event CanPlaceOnAvatarHandDelegate CanPlaceOnAvatarHandsAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public LevelGivenToCharacterForExchangeItemHandler() { }

	[CompilerGenerated]
	public void add_CanPlaceOnAvatarHandsAction(CanPlaceOnAvatarHandDelegate value) { }

	protected override void Awake() { }

	public override ReadOnlyCollection<Int32> GetAvatarIds() { }

	protected override bool IsReceivingGiftMeetsTheCondition() { }

	protected override void OnAcceptedByCharacter() { }

	private void OnCurrentAnimationEnd(TrackEntry trackEntry) { }

	protected override void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnGiveAnimationEnd(TrackEntry trackEntry) { }

	protected override void OnPlacedOnAvatarWithHands(ILevelAvatar avatar, ItemOnAvatarType type, MethodGivenToCharacter givenMethod) { }

	[CompilerGenerated]
	public void remove_CanPlaceOnAvatarHandsAction(CanPlaceOnAvatarHandDelegate value) { }

	private void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

