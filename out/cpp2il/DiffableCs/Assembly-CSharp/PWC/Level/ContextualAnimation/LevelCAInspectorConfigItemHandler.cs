namespace PWC.Level.ContextualAnimation;

public class LevelCAInspectorConfigItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x88
	[SerializeField]
	private LevelCAInspectorConfig _inspectorConfig; //Field offset: 0x90

	public LevelCAInspectorConfigItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

