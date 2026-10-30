namespace Unity.Networking.Transport;

[Extension]
public static class NetworkPipelineParametersExtensions
{

	[Extension]
	public static NetworkPipelineParams GetPipelineParameters(ref NetworkSettings settings) { }

	[Extension]
	[Obsolete("Will be removed in Unity Transport 2.0.")]
	public static NetworkSettings WithPipelineParameters(ref NetworkSettings settings, int initialCapacity = 0) { }

}

