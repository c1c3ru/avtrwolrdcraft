namespace Game.Level.AccessableObjects;

public class LevelAOScareSkeletonHandler : LevelAOScareItemHandler
{
	[SerializeField]
	private LevelStaticSignRobot _skeleton; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onScareAction; //Field offset: 0x28

	public LevelAOScareSkeletonHandler() { }

	public virtual void Scare() { }

}

