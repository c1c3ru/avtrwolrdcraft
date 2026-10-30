namespace UnityEngine.AddressableAssets.Utility;

internal static class SerializationUtilities
{
	public enum ObjectType
	{
		AsciiString = 0,
		UnicodeString = 1,
		UInt16 = 2,
		UInt32 = 3,
		Int32 = 4,
		Hash128 = 5,
		Type = 6,
		JsonObject = 7,
	}


	internal static int ReadInt32FromByteArray(Byte[] data, int offset) { }

	internal static object ReadObjectFromByteArray(Byte[] keyData, int dataIndex) { }

	internal static int WriteInt32ToByteArray(Byte[] data, int val, int offset) { }

	internal static int WriteObjectToByteList(object obj, List<Byte> buffer) { }

}

