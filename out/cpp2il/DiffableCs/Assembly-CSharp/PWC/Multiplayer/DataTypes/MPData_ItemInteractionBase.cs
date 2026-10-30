namespace PWC.Multiplayer.DataTypes;

public abstract class MPData_ItemInteractionBase : MPDataBase
{
	[JsonProperty("item")]
	public string itemSceneGuid; //Field offset: 0x28
	[JsonProperty("handler")]
	public string handlerSceneGuid; //Field offset: 0x30
	[JsonProperty("target")]
	public string targetSceneGuid; //Field offset: 0x38
	[JsonProperty("tci")]
	public int targetComponentIndex; //Field offset: 0x40
	public bool isFlipped; //Field offset: 0x44
	[JsonProperty("fromPos")]
	public PJVector2 fromPosition; //Field offset: 0x48

	protected MPData_ItemInteractionBase() { }

	public bool TryGetSceneObjects(out PDSceneObject itemSceneObject, out PDSceneObject handlerSceneObject, out PDSceneObject targetSceneObject) { }

	public bool TryGetSceneObjectsAndConsumer(out PDSceneObject itemSceneObject, out PDSceneObject handlerSceneObject, out ILevelConsumer targetConsumer) { }

}

