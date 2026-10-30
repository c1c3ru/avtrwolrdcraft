namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerFlightTicketItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configsSitting; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configsStanding; //Field offset: 0x90
	private LevelToddler _toddler; //Field offset: 0x98

	public LevelCAToddlerFlightTicketItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

