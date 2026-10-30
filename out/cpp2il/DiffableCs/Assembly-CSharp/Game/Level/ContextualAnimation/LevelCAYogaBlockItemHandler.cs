namespace Game.Level.ContextualAnimation;

public class LevelCAYogaBlockItemHandler : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	private string _skinName; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAYogaBlockItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

}

