namespace Game.Level.ContextualAnimation;

public class LevelCAShampooChairClientDropAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private LevelDropArea _hairDresserDropArea; //Field offset: 0x98
	[SerializeField]
	private LevelDrinkDispenser _dispenser; //Field offset: 0xA0

	public LevelCAShampooChairClientDropAreaHandler() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

