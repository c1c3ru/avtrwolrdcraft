namespace Unity.Networking.Transport.Utilities;

public struct FragmentationUtility
{
	internal struct Parameters : INetworkParameter
	{
		internal const int k_DefaultPayloadCapacity = 4096; //Field offset: 0x0
		public int PayloadCapacity; //Field offset: 0x0

		public override bool Validate() { }

	}


}

