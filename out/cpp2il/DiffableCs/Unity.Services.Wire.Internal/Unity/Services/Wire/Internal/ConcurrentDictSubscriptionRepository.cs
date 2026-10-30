namespace Unity.Services.Wire.Internal;

internal class ConcurrentDictSubscriptionRepository : ISubscriptionRepository
{
	public ConcurrentDictionary<String, Subscription> Subscriptions; //Field offset: 0x10
	[CompilerGenerated]
	private Action<Int32> SubscriptionCountChanged; //Field offset: 0x18

	public override event Action<Int32> SubscriptionCountChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override bool IsEmpty
	{
		 get { } //Length: 80
	}

	public ConcurrentDictSubscriptionRepository() { }

	[CompilerGenerated]
	public override void add_SubscriptionCountChanged(Action<Int32> value) { }

	public override void Clear() { }

	public override bool get_IsEmpty() { }

	public override IEnumerable<KeyValuePair`2<String, Subscription>> GetAll() { }

	public override Subscription GetSub(string channel) { }

	public override Subscription GetSub(Subscription sub) { }

	public bool IsAlreadySubscribed(string alias) { }

	public override bool IsAlreadySubscribed(Subscription sub) { }

	public override bool IsRecovering(Subscription sub) { }

	public override void OnSocketClosed() { }

	public override void OnSubscriptionComplete(Subscription sub, SubscribeResult res) { }

	public override void RecoverSubscriptions(Reply reply) { }

	[CompilerGenerated]
	public override void remove_SubscriptionCountChanged(Action<Int32> value) { }

	public override void RemoveSub(Subscription sub) { }

}

