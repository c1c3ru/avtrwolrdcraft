namespace PWC.Multiplayer.DataTypes;

public class MPData_CA : MPDataBase
{
	[JsonProperty("target")]
	public string targetSceneGuid; //Field offset: 0x28
	[JsonProperty("ca")]
	public string caSceneGuid; //Field offset: 0x30
	[JsonProperty("name")]
	public string caName; //Field offset: 0x38
	[JsonProperty("conf")]
	public LevelCAConfig caConfig; //Field offset: 0x40
	[JsonProperty("caotrd")]
	public MPOneCallGeneratorData caOneCallGeneratorData; //Field offset: 0x48

	public MPData_CA() { }

	public virtual void HandleReceviedData() { }

}

