namespace Game.Level.ContextualAnimation;

public abstract class LevelCAGiftExchangeItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public LevelCAGiftExchangeItemHandler <>4__this; //Field offset: 0x10
		public LevelItemCallback onBeginThrow; //Field offset: 0x18
		public LevelItemCallback onComplete; //Field offset: 0x20

		public <>c__DisplayClass14_0() { }

		internal void <StartReceivingSequence>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_1
	{
		public LevelCharacter character; //Field offset: 0x10
		public <>c__DisplayClass14_0 CS$<>8__locals1; //Field offset: 0x18
		public LevelItemCallback <>9__2; //Field offset: 0x20

		public <>c__DisplayClass14_1() { }

		internal void <StartReceivingSequence>b__1() { }

		internal void <StartReceivingSequence>b__2(LevelItem thrownGift) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public LevelItem gift; //Field offset: 0x10
		public Vector2 source; //Field offset: 0x18
		public Vector2 destination; //Field offset: 0x20
		public float arcFactor; //Field offset: 0x28
		public LevelItemCallback onComplete; //Field offset: 0x30

		public <>c__DisplayClass23_0() { }

		internal void <ThrowGift>b__0(float t) { }

		internal void <ThrowGift>b__1() { }

	}

	internal sealed class LevelItemCallback : MulticastDelegate
	{

		public LevelItemCallback(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(LevelItem item, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(LevelItem item) { }

	}

	private const float THROW_SPEED = 5; //Field offset: 0x0
	private const float DONATION_RADIUS = 4; //Field offset: 0x0
	private const float DONATION_CIRCLE_X_OFFSET = 4; //Field offset: 0x0
	[SerializeField]
	protected PDPrefabReference[] _giftsPDPrefabReferences; //Field offset: 0x88
	[SerializeField]
	protected String[] _clothingGiftsName; //Field offset: 0x90
	protected LevelCharacter _currentCharacter; //Field offset: 0x98
	protected bool _isReceivingGift; //Field offset: 0xA0
	private int _endDonationSequenceTweenID; //Field offset: 0xA4

	protected LevelCAGiftExchangeItemHandler() { }

	private ReferenceType ChooseRandomTypeOfGift() { }

	protected override LevelItem CreateClothingGift(LevelCharacter character, string pdPrefabGUID) { }

	protected override LevelItem CreateGift(LevelCharacter character, string pdPrefabGUID) { }

	private void EndRecieveSequence() { }

	protected abstract string GetGiveAnimationName() { }

	protected override string GetRandomClothingName() { }

	protected override string GetRandomPDPrefabGUID() { }

	protected override List<LevelCharacter> GetRelevantCharactersInCircle() { }

	protected override Dictionary<Int32, String> GetSpecialClothingGiftsByCharacterIDDictionary() { }

	protected override Dictionary<Int32, String> GetSpecialGiftsByCharacterIDDictionary() { }

	public virtual SpineType GetSpineType() { }

	private bool IsSpecialCharacter(int characterID, out string giftReference, out ReferenceType type) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected override void OnGiftReceived(LevelCharacter giver, LevelItem gift) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected override void PutGiftInCharacterHand(LevelCharacter character, LevelItem gift) { }

	protected void StartReceivingSequence(LevelItemCallback onComplete = null, LevelItemCallback onBeginThrow = null) { }

	protected void ThrowGift(Vector2 source, Vector2 destination, LevelItem gift, LevelItemCallback onComplete) { }

}

