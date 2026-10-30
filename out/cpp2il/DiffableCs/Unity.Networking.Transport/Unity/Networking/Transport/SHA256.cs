namespace Unity.Networking.Transport;

internal static class SHA256
{
	public struct SHA256State
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <buffer>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <state>e__FixedBuffer
		{
			public uint FixedElementField; //Field offset: 0x0

		}

		private static readonly UInt32[] K; //Field offset: 0x0
		[FixedBuffer(typeof(uint), 8)]
		public <state>e__FixedBuffer state; //Field offset: 0x0
		[FixedBuffer(typeof(byte), 64)]
		public <buffer>e__FixedBuffer buffer; //Field offset: 0x20
		private ulong count; //Field offset: 0x60

		private static SHA256State() { }

		[CompilerGenerated]
		internal static uint <Transform>g__Ch|8_5(uint x, uint y, uint z) { }

		[CompilerGenerated]
		internal static uint <Transform>g__Maj|8_6(uint x, uint y, uint z) { }

		[CompilerGenerated]
		internal static uint <Transform>g__ROTR32|8_0(uint x, byte n) { }

		[CompilerGenerated]
		internal static uint <Transform>g__S0|8_1(uint x) { }

		[CompilerGenerated]
		internal static uint <Transform>g__s0|8_3(uint x) { }

		[CompilerGenerated]
		internal static uint <Transform>g__S1|8_2(uint x) { }

		[CompilerGenerated]
		internal static uint <Transform>g__s1|8_4(uint x) { }

		public static SHA256State Create() { }

		public void Final(Byte* dest) { }

		private void Transform(UInt32* data) { }

		public void Update(Byte* data, int length) { }

		private void WriteByteBlock() { }

	}


}

