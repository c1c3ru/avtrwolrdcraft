namespace Game.Level;

public class LevelRecipeSecretsInLevelListener : MonoBehaviour
{
	internal class RecipeSecret
	{
		public int secretID; //Field offset: 0x10
		public PDPrefabReference item1; //Field offset: 0x18
		public PDPrefabReference item2; //Field offset: 0x20

		public RecipeSecret() { }

	}

	[SerializeField]
	private LevelType _secretLeveType; //Field offset: 0x20
	[SerializeField]
	private List<RecipeSecret> recipeSecrets; //Field offset: 0x28

	public LevelRecipeSecretsInLevelListener() { }

	private void Awake() { }

	private void OnApplyRecipe(LevelItem levelItem_1, LevelItem levelItem_2) { }

	private void OnDestroy() { }

}

