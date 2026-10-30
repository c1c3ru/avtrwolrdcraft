namespace Unity.Networking.Transport.Utilities;

[Extension]
public static class FragmentationStageParameterExtensions
{

	[Extension]
	public static Parameters GetFragmentationStageParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkSettings WithFragmentationStageParameters(ref NetworkSettings settings, int payloadCapacity = 4096) { }

}

