namespace PWC.Game.Level;

public static class LevelCatSkinsCAData
{
	private static readonly Dictionary<String, Type> _map; //Field offset: 0x0
	private static readonly Dictionary<CatClothingType, Type> _categoriesMap; //Field offset: 0x8

	private static LevelCatSkinsCAData() { }

	public static bool TryGetCAHandlerType(string skinName, out Type handlerType) { }

}

