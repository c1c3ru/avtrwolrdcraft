namespace PWC.Level;

public interface IEditor_LevelPDPrefabOverrideTest
{

	public HashSet<Type> Editor_GetAllowedAddedComponentTypes() { }

	public Dictionary<Type, Object> Editor_GetAllowedOverrides() { }

	public bool Editor_ShouldAllowAllAddedAndRemovedComponentTypes() { }

}

