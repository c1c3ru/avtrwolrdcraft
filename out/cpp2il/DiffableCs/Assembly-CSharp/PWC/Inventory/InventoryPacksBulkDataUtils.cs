namespace PWC.Inventory;

public static class InventoryPacksBulkDataUtils
{
	private class InventoryPackBulkDataFlags
	{
		public List<InventoryFlagType> flagsList; //Field offset: 0x10

		public InventoryPackBulkDataFlags() { }

	}

	private const string BULKDATA_FLAG_INTERACTION = "BulkData_Flag_Interaction"; //Field offset: 0x0

	private static string GetKey() { }

	public static bool IsBulkDataInteractionFlagExist(InventoryFlagType flagType) { }

	public static void SetFlagBulkDataInteractionPerformed(InventoryFlagType flagType) { }

	public static void SetFlagIsClaimedForBulkDataReset(string flag) { }

}

