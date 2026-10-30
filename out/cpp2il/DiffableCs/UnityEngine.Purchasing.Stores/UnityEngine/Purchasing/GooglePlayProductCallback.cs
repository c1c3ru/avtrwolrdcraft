namespace UnityEngine.Purchasing;

internal class GooglePlayProductCallback : IGoogleProductCallback
{
	[Nullable(2)]
	private IGooglePlayConfigurationInternal m_GooglePlayConfigurationInternal; //Field offset: 0x10

	public GooglePlayProductCallback() { }

	public override void NotifyQueryProductDetailsFailed(int retryCount) { }

	[NullableContext(1)]
	public override void SetStoreConfiguration(IGooglePlayConfigurationInternal configuration) { }

}

