namespace Game.Level;

public class LevelFishingRodBaitArea : LevelDropArea
{

	public LevelFishingRodBaitArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	private Vector2 GetBaitDropPosition(LevelFishingRodBait bait) { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	public virtual float GetXPositionOnDropArea(float fromXPosition, LevelItem levelItem, Nullable<Single> optionalYPosition = null) { }

}

