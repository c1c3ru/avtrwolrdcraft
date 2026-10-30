namespace PWC.Multiplayer.DataTypes;

public static class MPDataTypesMap
{
	private static readonly Dictionary<MPDataType, Type> _map; //Field offset: 0x0
	private static Dictionary<Type, MPDataType> _reversedMap; //Field offset: 0x8

	private static MPDataTypesMap() { }

	public static Type GetDataClassTypeFromDataType(MPDataType enumType) { }

	public static MPDataType GetDataTypeFromClassType(Type classType) { }

}

