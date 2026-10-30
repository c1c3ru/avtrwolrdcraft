namespace PWC.Multiplayer.DataTypes;

public class MPData_ItemBeginDrag : MPDataBase
{
	[JsonProperty("sg")]
	public string sceneGuid; //Field offset: 0x28
	[JsonProperty("bdicd")]
	public MPOneCallGeneratorData beginDragOneCalldata; //Field offset: 0x30

	public MPData_ItemBeginDrag() { }

	public virtual void HandleReceviedData() { }

}

