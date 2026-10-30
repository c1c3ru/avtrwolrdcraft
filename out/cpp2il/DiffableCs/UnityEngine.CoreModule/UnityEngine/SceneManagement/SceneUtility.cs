namespace UnityEngine.SceneManagement;

[NativeHeader("Runtime/Export/SceneManager/SceneUtility.bindings.h")]
public static class SceneUtility
{

	[StaticAccessor("SceneUtilityBindings", StaticAccessorType::DoubleColon (2))]
	public static string GetScenePathByBuildIndex(int buildIndex) { }

}

