namespace Game.Level;

public class LevelLakeHangerArea : LevelSingleItemDropArea
{
	[SerializeField]
	private LakeHangedItemType _campsiteHangedItemType; //Field offset: 0xD8

	public LevelLakeHangerArea() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

