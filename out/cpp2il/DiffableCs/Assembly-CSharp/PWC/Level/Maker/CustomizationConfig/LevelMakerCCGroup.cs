namespace PWC.Level.Maker.CustomizationConfig;

public class LevelMakerCCGroup : LevelMakerCCBase
{
	public List<String> items; //Field offset: 0x20
	private LevelMakerCCBase[] _actualItems; //Field offset: 0x28

	public LevelMakerCCGroup() { }

	private void FillItems(LevelMakerCCGroup root, HashSet<LevelMakerCCBase> results, HashSet<LevelMakerCCGroup> iteratedGroups, GameObject context) { }

	public LevelMakerCCBase[] GetActualItems(GameObject context) { }

}

