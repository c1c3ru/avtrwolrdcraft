namespace Game.Store;

public class StoreIAPHandle
{
	public readonly string itemGuid; //Field offset: 0x10
	public readonly string productName; //Field offset: 0x18
	public readonly Action<StoreClaimItemCloudResponse> onSuccess; //Field offset: 0x20
	public readonly Action<ErrorCode, IAPResult, Nullable`1<Int32>> onFailure; //Field offset: 0x28
	private StoreClaimItemCloudResponse _cloudResponse; //Field offset: 0x30

	public private StoreClaimItemCloudResponse CloudResponse
	{
		 get { } //Length: 8
		private set { } //Length: 8
	}

	public StoreIAPHandle(string itemGuid, string productName, Action<StoreClaimItemCloudResponse> onSuccess, Action<ErrorCode, IAPResult, Nullable`1<Int32>> onFailure) { }

	public StoreClaimItemCloudResponse get_CloudResponse() { }

	public void OnIAPEnded(IAPResult result) { }

	private void set_CloudResponse(StoreClaimItemCloudResponse value) { }

	public void SetCloudResponse(StoreClaimItemCloudResponse cloudResponse) { }

	public void StartBuyProcess() { }

}

