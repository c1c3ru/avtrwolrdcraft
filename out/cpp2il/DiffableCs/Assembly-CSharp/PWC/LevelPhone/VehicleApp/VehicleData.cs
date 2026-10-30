namespace PWC.LevelPhone.VehicleApp;

public class VehicleData
{
	public VehicleType vehicleType; //Field offset: 0x10
	public PDPrefabReference pdPrefabReference; //Field offset: 0x18
	public Sprite icon; //Field offset: 0x20
	public bool requiresPurchase; //Field offset: 0x28
	[ConditionalField("requiresPurchase", True, True, (array) null)]
	public InventoryFlagType requiredFlagType; //Field offset: 0x2C
	public bool requiresSecret; //Field offset: 0x30
	[ConditionalField("requiresSecret", True, True, (array) null)]
	public SecretFullId secretID; //Field offset: 0x38
	public string orderVehicleSound; //Field offset: 0x40
	public string returnVehicleSound; //Field offset: 0x48
	[ConditionalField("requiresPurchase", False, True, (array) null)]
	public LevelType levelDefaultData; //Field offset: 0x50

	public VehicleData() { }

}

