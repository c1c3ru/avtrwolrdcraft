namespace Game.Store;

public class StoreDataCloudResponse : Response
{
	public readonly StoreData storeData; //Field offset: 0x58
	public readonly ClientMessage storeClientMessage; //Field offset: 0x60

	public StoreDataCloudResponse(string responseText) { }

}

