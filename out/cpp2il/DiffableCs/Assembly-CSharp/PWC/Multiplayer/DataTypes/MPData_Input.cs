namespace PWC.Multiplayer.DataTypes;

public class MPData_Input : MPDataBase
{
	[JsonProperty("tp")]
	public MPInputEventType type; //Field offset: 0x28
	[JsonProperty("sg")]
	public string sceneGuid; //Field offset: 0x30
	[JsonProperty("pos")]
	public PJVector2 position; //Field offset: 0x38
	[JsonProperty("iotrd")]
	public MPOneCallGeneratorData intputOneCallGeneratorData; //Field offset: 0x40
	[JsonProperty("prgs")]
	public string pointerRaycastGameObjectSceneGuid; //Field offset: 0x48

	public MPData_Input() { }

	public virtual void HandleReceviedData() { }

}

