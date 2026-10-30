namespace Game.Level;

public class LevelBalloonPopItemHandler : LevelBalloonPopHandler
{
	[SerializeField]
	private LevelInflatedBalloonItemHandler _balloon; //Field offset: 0x58
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x60

	public LevelBalloonPopItemHandler() { }

	protected virtual void DestroyBalloon() { }

}

