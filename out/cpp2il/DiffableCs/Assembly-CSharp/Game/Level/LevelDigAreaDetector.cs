namespace Game.Level;

public class LevelDigAreaDetector : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private LevelMetalDetectorItemHandler _levelMetalDetectorItemHandler; //Field offset: 0xA0
	public int NumberOfDetectedHole; //Field offset: 0xA8

	public LevelDigAreaDetector() { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

}

