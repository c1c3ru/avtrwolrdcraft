namespace PWC.Multiplayer.DataTypes;

public class MPData_StartGame : MPData_StartScene
{
	[JsonProperty("puid")]
	public int playerUID; //Field offset: 0x60
	public string sessionGUID; //Field offset: 0x68
	public Dictionary<Int32, String> playersInScenes; //Field offset: 0x70
	public HashSet<Int32> hostAvatarIds; //Field offset: 0x78
	public TimeOfDay timeOfDay; //Field offset: 0x80
	public Int32[] weatherPerWorld; //Field offset: 0x88
	[JsonProperty("inventory")]
	public InventoryData inventoryData; //Field offset: 0x90
	[JsonProperty("picData")]
	public Dictionary<Int32, AvatarSpineData> playersAvatarSpineDataForPictures; //Field offset: 0x98
	[JsonProperty("carsData")]
	public List<AvatarSpineData> carsSpineData; //Field offset: 0xA0
	[JsonProperty("apu")]
	public HashSet<Int32> allPlayersUIDs; //Field offset: 0xA8

	public MPData_StartGame() { }

	public virtual void HandleReceviedData() { }

}

