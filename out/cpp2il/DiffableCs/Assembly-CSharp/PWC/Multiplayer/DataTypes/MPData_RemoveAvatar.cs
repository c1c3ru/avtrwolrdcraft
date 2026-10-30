namespace PWC.Multiplayer.DataTypes;

public class MPData_RemoveAvatar : MPDataBase
{
	[JsonProperty("aid")]
	public string sceneGuid; //Field offset: 0x28
	[JsonProperty("rci")]
	public bool releaseChildrenItems; //Field offset: 0x30
	[JsonProperty("ssid")]
	public string gameSceneIdToSet; //Field offset: 0x38

	public MPData_RemoveAvatar() { }

	public virtual void HandleReceviedData() { }

}

