namespace PWC.Game.Level;

public static class LevelHorseSkinsCAData
{
	private static readonly Dictionary<String, Type> _map; //Field offset: 0x0
	private static readonly Dictionary<HorseClothingType, Type> _categoriesMap; //Field offset: 0x8

	private static LevelHorseSkinsCAData() { }

	public static bool TryGetCAHandlerType(string skinName, out Type handlerType) { }

}

