namespace PWC.Level;

public class LevelNewPetManager : LevelNewAvatarManager
{
	[SerializeField]
	private PDPrefabReference _prefabToSpawnOn; //Field offset: 0x40

	public LevelNewPetManager() { }

	protected virtual void OnAvatarSpawnPostInit() { }

}

