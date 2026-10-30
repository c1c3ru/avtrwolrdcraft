namespace Game.Level.ContextualAnimation;

public class LevelCADoughCutterItemHandler : LevelCAItemHandlerBase
{
	private const string ROLLING_CUTTIN_L_ANIMATION_NAME = "Rolling_Cutting_L"; //Field offset: 0x0
	private const string ROLLING_CUTTIN_R_ANIMATION_NAME = "Rolling_Cutting_R"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCADoughCutterItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

