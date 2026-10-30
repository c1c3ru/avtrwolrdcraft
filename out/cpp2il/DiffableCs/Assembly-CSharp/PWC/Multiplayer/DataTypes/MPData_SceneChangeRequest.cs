namespace PWC.Multiplayer.DataTypes;

public class MPData_SceneChangeRequest : MPDataBase
{
	[JsonProperty("rguid")]
	public string requestGuid; //Field offset: 0x28
	[JsonProperty("fsn")]
	public string fromSceneId; //Field offset: 0x30
	[JsonProperty("tsn")]
	public string toSceneId; //Field offset: 0x38
	[JsonProperty("sData")]
	public MPSceneData sceneData; //Field offset: 0x40

	public MPData_SceneChangeRequest() { }

	public virtual void HandleReceviedData() { }

}

