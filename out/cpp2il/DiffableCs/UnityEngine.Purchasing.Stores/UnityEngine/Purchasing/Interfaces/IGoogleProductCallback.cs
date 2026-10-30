namespace UnityEngine.Purchasing.Interfaces;

[NullableContext(1)]
internal interface IGoogleProductCallback
{

	public void NotifyQueryProductDetailsFailed(int retryCount) { }

	public void SetStoreConfiguration(IGooglePlayConfigurationInternal configuration) { }

}

