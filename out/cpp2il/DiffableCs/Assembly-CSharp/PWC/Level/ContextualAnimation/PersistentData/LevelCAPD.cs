namespace PWC.Level.ContextualAnimation.PersistentData;

public class LevelCAPD
{
	public CAPlayType playType; //Field offset: 0x10
	public LevelCAConfig config; //Field offset: 0x18
	public string handlerSceneGuid; //Field offset: 0x20
	public string handlerName; //Field offset: 0x28
	public bool isPlaying; //Field offset: 0x30

	public LevelCAPD() { }

}

