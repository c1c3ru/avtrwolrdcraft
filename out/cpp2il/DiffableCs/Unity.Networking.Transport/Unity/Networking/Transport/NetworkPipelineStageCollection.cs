namespace Unity.Networking.Transport;

public static class NetworkPipelineStageCollection
{
	internal static List<INetworkPipelineStage> m_stages; //Field offset: 0x0

	private static NetworkPipelineStageCollection() { }

	public static NetworkPipelineStageId GetStageId(Type stageType) { }

	public static void RegisterPipelineStage(INetworkPipelineStage stage) { }

}

