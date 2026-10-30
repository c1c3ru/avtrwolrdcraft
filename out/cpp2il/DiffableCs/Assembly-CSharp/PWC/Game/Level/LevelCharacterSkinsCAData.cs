namespace PWC.Game.Level;

public static class LevelCharacterSkinsCAData
{
	private static readonly Dictionary<String, Type> _map; //Field offset: 0x0
	private static readonly Dictionary<CharacterClothingType, Type> _categoriesMap; //Field offset: 0x8
	private static readonly Dictionary<ClothingType, Type> _specialTypeMap; //Field offset: 0x10

	private static LevelCharacterSkinsCAData() { }

	public static bool TryGetCAHandlerType(string skinName, out Type handlerType) { }

	private static bool TryGetSpecialHandlerType(string skinName, out Type handlerType) { }

}

