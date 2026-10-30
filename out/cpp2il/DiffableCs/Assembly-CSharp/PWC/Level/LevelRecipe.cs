namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Recipe")]
public class LevelRecipe : ScriptableObject
{
	internal class Result
	{
		public PDPrefabReference withItem; //Field offset: 0x10
		public PDPrefabReference outcome; //Field offset: 0x18

		public Result() { }

		public PDPrefab GetOutcomePrefab() { }

		public PDPrefab GetWithItemPrefab() { }

	}

	public PDPrefabReference item; //Field offset: 0x18
	public List<Result> results; //Field offset: 0x20

	public LevelRecipe() { }

}

