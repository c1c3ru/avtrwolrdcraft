namespace Unity.Networking.Transport.Utilities;

[Extension]
public static class SimulatorStageParameterExtensions
{

	[Extension]
	public static Parameters GetSimulatorStageParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkSettings WithSimulatorStageParameters(ref NetworkSettings settings, int maxPacketCount, int maxPacketSize, int packetDelayMs = 0, int packetJitterMs = 0, int packetDropInterval = 0, int packetDropPercentage = 0, int fuzzFactor = 0, int fuzzOffset = 0, uint randomSeed = 0) { }

}

