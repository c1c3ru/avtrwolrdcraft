namespace Game.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/RecipeSecret")]
public class LevelRecipeSecret : ConditionResolverAsset
{
	public SecretFullId secretFullID; //Field offset: 0x20
	public PDPrefabReference item1; //Field offset: 0x28
	public PDPrefabReference item2; //Field offset: 0x30

	public LevelRecipeSecret() { }

}

