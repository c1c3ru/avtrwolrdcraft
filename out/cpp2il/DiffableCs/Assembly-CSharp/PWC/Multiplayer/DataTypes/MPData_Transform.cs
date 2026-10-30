namespace PWC.Multiplayer.DataTypes;

public class MPData_Transform : MPDataBase
{
	[JsonProperty("sg")]
	public string sceneGuid; //Field offset: 0x28
	[JsonProperty("poss")]
	public List<PJVector2> positions; //Field offset: 0x30
	[JsonProperty("if")]
	public bool isFlipped; //Field offset: 0x38
	[JsonProperty("dur")]
	public float duration; //Field offset: 0x3C
	[JsonProperty("par")]
	public string parentSceneGuid; //Field offset: 0x40
	[JsonProperty("ssp")]
	public Nullable<Boolean> shouldSetParent; //Field offset: 0x48

	public MPData_Transform() { }

	public virtual void HandleReceviedData() { }

}

