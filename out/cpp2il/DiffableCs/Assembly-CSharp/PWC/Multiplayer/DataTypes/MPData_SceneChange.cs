namespace PWC.Multiplayer.DataTypes;

public class MPData_SceneChange : MPDataBase
{
	[JsonProperty("sceneId")]
	public string sceneId; //Field offset: 0x28

	public MPData_SceneChange() { }

	public virtual void HandleReceviedData() { }

}

