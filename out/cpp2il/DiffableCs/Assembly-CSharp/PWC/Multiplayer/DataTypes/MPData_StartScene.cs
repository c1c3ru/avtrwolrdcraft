namespace PWC.Multiplayer.DataTypes;

public class MPData_StartScene : MPDataBase
{
	[JsonProperty("rguid")]
	public string requestGuid; //Field offset: 0x28
	[JsonProperty("scene")]
	public string sceneId; //Field offset: 0x30
	[JsonProperty("sData")]
	public MPSceneData sceneData; //Field offset: 0x38
	[JsonProperty("rSeed")]
	public Nullable<Int32> randomGeneratorSeed; //Field offset: 0x40
	[JsonProperty("hcc")]
	public Nullable<Int32> hostChangesCounter; //Field offset: 0x48
	[JsonProperty("gp")]
	public string guidPrefix; //Field offset: 0x50
	[JsonProperty("uis")]
	public HashSet<Int32> uidsInScene; //Field offset: 0x58

	public MPData_StartScene() { }

	public virtual void HandleReceviedData() { }

	public virtual bool ShouldHostHanldeData() { }

}

