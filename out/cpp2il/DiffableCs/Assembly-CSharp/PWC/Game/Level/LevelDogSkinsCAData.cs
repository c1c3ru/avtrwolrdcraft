namespace PWC.Game.Level;

public static class LevelDogSkinsCAData
{
	private static readonly Dictionary<String, Type> _map; //Field offset: 0x0
	private static readonly Dictionary<DogClothingType, Type> _categoriesMap; //Field offset: 0x8

	private static LevelDogSkinsCAData() { }

	public static bool TryGetCAHandlerType(string skinName, out Type handlerType) { }

}

