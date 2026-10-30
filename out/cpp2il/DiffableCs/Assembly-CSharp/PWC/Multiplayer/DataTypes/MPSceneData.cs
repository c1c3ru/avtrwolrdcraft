namespace PWC.Multiplayer.DataTypes;

public class MPSceneData
{
	[JsonProperty("sceneId")]
	public string sceneId; //Field offset: 0x10
	[JsonProperty("path")]
	public string filePath; //Field offset: 0x18
	[JsonProperty("json")]
	public string json; //Field offset: 0x20
	[JsonProperty("aDatas")]
	public List<MPAvatarData> avatarDatas; //Field offset: 0x28

	public MPSceneData() { }

	public bool IsValid(bool logErrorIfNotValid = true) { }

}

