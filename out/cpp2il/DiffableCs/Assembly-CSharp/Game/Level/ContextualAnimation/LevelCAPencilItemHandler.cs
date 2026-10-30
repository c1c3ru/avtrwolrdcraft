namespace Game.Level.ContextualAnimation;

public class LevelCAPencilItemHandler : LevelCAItemHandlerBase
{
	private const string PANCIL_ON_EAR_ANIMATION = "Pencil_On_Ear_Thinking_R"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAPencilItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

