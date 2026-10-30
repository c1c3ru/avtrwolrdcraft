namespace Game.Level.ContextualAnimation;

public class LevelCAToothbrushTeethSkinItemHandler : LevelCAToothbrushItemHandler
{
	[SerializeField]
	protected LevelMakeupDataItemHandler _makeupDataItemHandler; //Field offset: 0x98
	[SerializeField]
	private string _AddedSkinSound; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA8

	public LevelCAToothbrushTeethSkinItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

}

