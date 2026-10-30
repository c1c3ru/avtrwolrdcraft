namespace Game.Level.ContextualAnimation;

public class LevelCAShampooChairDropAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private LevelDropArea _clientDropArea; //Field offset: 0x98
	[SerializeField]
	private LevelDrinkDispenser _dispenser; //Field offset: 0xA0

	public LevelCAShampooChairDropAreaHandler() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

