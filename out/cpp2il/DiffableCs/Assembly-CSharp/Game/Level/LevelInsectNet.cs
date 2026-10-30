namespace Game.Level;

public class LevelInsectNet : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private Transform _catchPoint; //Field offset: 0x358

	public LevelInsectNet() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

}

