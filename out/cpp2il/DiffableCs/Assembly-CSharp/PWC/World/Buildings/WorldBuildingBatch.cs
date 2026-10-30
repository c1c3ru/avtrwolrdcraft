namespace PWC.World.Buildings;

public class WorldBuildingBatch
{
	public EnumBatchType enumBatchType; //Field offset: 0x10
	public List<WorldBuildingBatchGameObjects> batchGameObjects; //Field offset: 0x18

	public WorldBuildingBatch() { }

	public void ActivateGameObjects(int value) { }

	public int GetFlagsCount() { }

}

