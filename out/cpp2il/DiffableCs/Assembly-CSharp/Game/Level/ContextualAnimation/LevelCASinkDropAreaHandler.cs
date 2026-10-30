namespace Game.Level.ContextualAnimation;

public class LevelCASinkDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelDrinkDispenser _sink; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASinkDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

