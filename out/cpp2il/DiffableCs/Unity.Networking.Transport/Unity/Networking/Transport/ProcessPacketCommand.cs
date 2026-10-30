namespace Unity.Networking.Transport;

internal struct ProcessPacketCommand
{
	internal struct ProcessPacketCommandAs
	{
		internal struct AsAddressUpdate
		{
			public NetworkInterfaceEndPoint NewAddress; //Field offset: 0x0

		}

		internal struct AsConnectionAccept
		{
			public SessionIdToken ConnectionToken; //Field offset: 0x0

		}

		internal struct AsData
		{
			public int Offset; //Field offset: 0x0
			public int Length; //Field offset: 0x4
			public byte HasPipelineByte; //Field offset: 0x8

			public bool HasPipeline
			{
				 get { } //Length: 16
			}

			public bool get_HasPipeline() { }

		}

		internal struct AsDataWithImplicitConnectionAccept
		{
			public int Offset; //Field offset: 0x0
			public int Length; //Field offset: 0x4
			public byte HasPipelineByte; //Field offset: 0x8
			public SessionIdToken ConnectionToken; //Field offset: 0x9

			public bool HasPipeline
			{
				 get { } //Length: 16
			}

			public bool get_HasPipeline() { }

		}

		internal struct AsProtocolStatusUpdate
		{
			public int Status; //Field offset: 0x0

		}

		public AsAddressUpdate AddressUpdate; //Field offset: 0x0
		public AsConnectionAccept ConnectionAccept; //Field offset: 0x0
		public AsData Data; //Field offset: 0x0
		public AsDataWithImplicitConnectionAccept DataWithImplicitConnectionAccept; //Field offset: 0x0
		public AsProtocolStatusUpdate ProtocolStatusUpdate; //Field offset: 0x0

	}

	public ProcessPacketCommandType Type; //Field offset: 0x0
	public NetworkInterfaceEndPoint Address; //Field offset: 0x4
	public SessionIdToken SessionId; //Field offset: 0x40
	public ProcessPacketCommandAs As; //Field offset: 0x48

}

