namespace PWC.Multiplayer.DataTypes;

public class MPMetaData
{
	[JsonProperty("type")]
	public MPDataType dataType; //Field offset: 0x10

	public MPMetaData() { }

}

