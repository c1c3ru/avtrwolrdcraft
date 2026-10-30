namespace PWC.Level;

public interface IEditor_PSDToLevelPrefabVariantBase
{

	public void Editor_PSDToLevelPrefabVariantInit(Dictionary<String, Sprite> sprites) { }

	public bool Editor_PSDToLevelPrefabVariantTryGetChildrenToIgnoreInHierarchy(out HashSet<Transform>& hashSet) { }

}

