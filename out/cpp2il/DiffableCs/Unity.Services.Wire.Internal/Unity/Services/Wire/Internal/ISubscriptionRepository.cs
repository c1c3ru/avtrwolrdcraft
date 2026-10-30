namespace Unity.Services.Wire.Internal;

internal interface ISubscriptionRepository
{

	public event Action<Int32> SubscriptionCountChanged
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public bool IsEmpty
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_SubscriptionCountChanged(Action<Int32> value) { }

	public void Clear() { }

	public bool get_IsEmpty() { }

	public IEnumerable<KeyValuePair`2<String, Subscription>> GetAll() { }

	public Subscription GetSub(Subscription sub) { }

	public Subscription GetSub(string channel) { }

	public bool IsAlreadySubscribed(Subscription sub) { }

	public bool IsRecovering(Subscription sub) { }

	public void OnSocketClosed() { }

	public void OnSubscriptionComplete(Subscription sub, SubscribeResult result) { }

	public void RecoverSubscriptions(Reply reply) { }

	[CompilerGenerated]
	public void remove_SubscriptionCountChanged(Action<Int32> value) { }

	public void RemoveSub(Subscription sub) { }

}

