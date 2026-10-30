namespace PWC.Level.ContextualAnimation;

public class LevelCAInspectorConfigParentHandler : LevelCAParentHandlerBase
{
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x80
	[SerializeField]
	private LevelCAInspectorConfig _inspectorConfig; //Field offset: 0x88

	public LevelCAInspectorConfigParentHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

}

