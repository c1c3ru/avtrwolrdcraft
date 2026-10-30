namespace Store.Level;

public class LevelStorePackTilesSpawner : LevelStorePackSpawnLocation
{
	[SerializeField]
	private LevelMakerCustomizationStaticElementHandler _staticElement; //Field offset: 0x28

	public LevelMakerCustomizationStaticElementHandler StaticElement
	{
		 get { } //Length: 8
	}

	public LevelStorePackTilesSpawner() { }

	public LevelMakerCustomizationStaticElementHandler get_StaticElement() { }

}

