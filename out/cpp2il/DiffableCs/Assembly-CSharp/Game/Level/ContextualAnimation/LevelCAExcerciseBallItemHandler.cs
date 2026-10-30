namespace Game.Level.ContextualAnimation;

public class LevelCAExcerciseBallItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x90
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0x98
	[SerializeField]
	private string _skinName; //Field offset: 0xA0

	public LevelCAExcerciseBallItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

