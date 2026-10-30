namespace Game.Level;

public class LevelEventOnLabelDropAreaItemHandler : LevelEventOnLabelDropAreaItemHandlerBase
{
	[SerializeField]
	private LevelLabelHandler _labelHandler; //Field offset: 0x50

	public LevelEventOnLabelDropAreaItemHandler() { }

	protected virtual void Awake() { }

	protected virtual ILevelLabelHandler GetLabelHandler() { }

}

