namespace PWC.Multiplayer.DataTypes;

public class MPData_Message : MPDataBase
{
	public string sceneGuid; //Field offset: 0x28
	[JsonProperty("data")]
	public object dataObject; //Field offset: 0x30
	public MPEventIdentifierData idData; //Field offset: 0x38

	public MPData_Message() { }

	public virtual void HandleReceviedData() { }

}

