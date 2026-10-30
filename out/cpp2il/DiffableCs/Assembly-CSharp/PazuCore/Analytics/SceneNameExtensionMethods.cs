namespace PazuCore.Analytics;

[Extension]
public static class SceneNameExtensionMethods
{

	[Extension]
	public static bool CanHaveCreative(SceneName sceneName) { }

	[Extension]
	public static bool CanHaveCreativeWidgets(SceneName sceneName) { }

	[Extension]
	public static bool IsCoreScene(SceneName sceneName) { }

	[Extension]
	public static bool IsLibraryScene(SceneName sceneName) { }

}

