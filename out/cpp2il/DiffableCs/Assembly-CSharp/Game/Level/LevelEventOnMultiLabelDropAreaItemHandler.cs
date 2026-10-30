namespace Game.Level;

public class LevelEventOnMultiLabelDropAreaItemHandler : LevelEventOnLabelDropAreaItemHandlerBase
{
	[SerializeField]
	private LevelMultiLabelHandler _multiLabelHandler; //Field offset: 0x50

	public LevelEventOnMultiLabelDropAreaItemHandler() { }

	protected virtual void Awake() { }

	protected virtual ILevelLabelHandler GetLabelHandler() { }

}

