namespace PWC.UGC;

public static class UGCPrefabSpawnHelper
{
	internal enum SpawnResultType
	{
		None = 0,
		Success = 1,
		Error_NoSelection = 2,
		Error_NoSpaceOnSelection = 3,
		Error_SelectionNotCompatible = 4,
	}


	public static void ShowTooltipForResult(SpawnResultType spawnResultType, RectTransform targt) { }

	public static SpawnResultType TrySpawnItem(IUGCEntity onSelectedItem, IUGCSpawnableFromUI prefab, out IUGCEntity instance, bool isPlayable = true) { }

}

