namespace Game.Level.ContextualAnimation;

public class LevelCAUltrasoundProbeItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private float _maxScanDistance; //Field offset: 0x90
	[SerializeField]
	private LevelSecretSolveBroadcaster _secretSolveBroadcasterForFoundBaby; //Field offset: 0x98
	[SerializeField]
	private LevelSecretSolveBroadcaster _secretSolveBroadcasterForBabyNotFound; //Field offset: 0xA0

	public LevelCAUltrasoundProbeItemHandler() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

}

