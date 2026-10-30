namespace Game.Level.ContextualAnimation;

public class LevelCAStressBallItemHandler : LevelCAItemWithSkinHandlerBase
{
	[Range(1, 3)]
	[SerializeField]
	private int _skinIndex; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB8

	public LevelCAStressBallItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

