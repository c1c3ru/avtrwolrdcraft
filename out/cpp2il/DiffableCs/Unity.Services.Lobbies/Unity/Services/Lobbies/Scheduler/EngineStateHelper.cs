namespace Unity.Services.Lobbies.Scheduler;

internal static class EngineStateHelper
{
	public static bool IsPlaying; //Field offset: 0x0

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	public static void Init() { }

}

