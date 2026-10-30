namespace Unity.Networking.Transport.Utilities;

[Extension]
public static class ReliableStageParameterExtensions
{

	[Extension]
	public static Parameters GetReliableStageParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkSettings WithReliableStageParameters(ref NetworkSettings settings, int windowSize = 32) { }

}

