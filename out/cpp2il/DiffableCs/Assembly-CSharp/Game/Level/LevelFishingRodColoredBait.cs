namespace Game.Level;

public class LevelFishingRodColoredBait : LevelFishingRodBait
{
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _runtimeColoredSpriteHandler; //Field offset: 0x368

	public LevelFishingRodColoredBait() { }

	public virtual void HandleTarget(LevelItem levelItem) { }

}

